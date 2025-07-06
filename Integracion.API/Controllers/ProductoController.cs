using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TiendaVapes.Integracion.Domain.Entidades;
using TiendaVapes.Integracion.Services.Interfaces;

namespace TiendaVapes.Integracion.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _productoService;

        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Productos>>> ObtenerProductos()
        {
            var productos = await _productoService.ObtenerProductosAsync();
            return Ok(productos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Productos>> ObtenerProductoPorId(int id)
        {
            var producto = await _productoService.ObtenerProductoPorIdAsync(id);
            if (producto == null)
                return NotFound();

            return Ok(producto);
        }

        [HttpPost]
        public async Task<ActionResult> InsertarProducto([FromBody] Productos producto)
        {
            await _productoService.InsertarProductoAsync(producto);
            return Ok(new { mensaje = "Producto insertado correctamente" });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> ActualizarProducto(int id, [FromBody] Productos producto)
        {
            if (id != producto.ProductoId)
                return BadRequest("El ID no coincide");

            await _productoService.ActualizarProductoAsync(producto);
            return Ok(new { mensaje = "Producto actualizado correctamente" });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> EliminarProducto(int id)
        {
            await _productoService.EliminarProductoAsync(id);
            return Ok(new { mensaje = "Producto eliminado correctamente" });
        }
    }
}
