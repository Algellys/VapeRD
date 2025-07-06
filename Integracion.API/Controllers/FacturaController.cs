using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TiendaVapes.Integracion.Domain.Entidades;
using TiendaVapes.Integracion.Services.Interfaces;

namespace TiendaVapes.Integracion.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FacturaController : ControllerBase
    {
        private readonly IFacturaService facturaService;

        public FacturaController(IFacturaService facturaService)
        {
            this.facturaService = facturaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Facturas>>> Get()
        {
            var facturas = await facturaService.ObtenerFacturasAsync();
            return Ok(facturas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Facturas>> Get(int id)
        {
            var factura = await facturaService.ObtenerFacturaPorIdAsync(id);
            if (factura == null)
                return NotFound();

            return Ok(factura);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Facturas factura)
        {
            await facturaService.InsertarFacturaAsync(factura);
            return Ok(new { mensaje = "Factura insertada correctamente" });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Facturas factura)
        {
            if (id != factura.FacturaId)
                return BadRequest("El ID no coincide");

            await facturaService.ActualizarFacturaAsync(factura);
            return Ok(new { mensaje = "Factura actualizada correctamente" });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await facturaService.EliminarFacturaAsync(id);
            return Ok(new { mensaje = "Factura eliminada correctamente" });
        }
    }
}
