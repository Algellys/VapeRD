using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TiendaVapes.Core.API.Services;
using TiendaVapes.Core.Domain;
using TiendaVapes.Core.Domain.Entidades;

namespace TiendaVapes.Core.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoService _productoService;

        public ProductosController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpGet]
        public async Task<IEnumerable<Producto>> Get()
        {
            return await _productoService.ObtenerProductosAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> Get(int id)
        {
            var producto = await _productoService.ObtenerProductoPorIdAsync(id);
            if (producto == null)
                return NotFound();
            return producto;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Producto producto)
        {
            await _productoService.InsertarProductoAsync(producto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Producto producto)
        {
            producto.ProductoId = id;
            await _productoService.ActualizarProductoAsync(producto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productoService.EliminarProductoAsync(id);
            return Ok();
        }
    }
}
