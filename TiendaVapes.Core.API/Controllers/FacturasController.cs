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
    public class FacturasController : ControllerBase
    {
        private readonly IFacturaService _facturaService;

        public FacturasController(IFacturaService facturaService)
        {
            _facturaService = facturaService;
        }

        [HttpGet]
        public async Task<IEnumerable<Facturas>> Get()
        {
            return await _facturaService.ObtenerFacturasAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Facturas>> Get(int id)
        {
            var factura = await _facturaService.ObtenerFacturaPorIdAsync(id);
            if (factura == null)
                return NotFound();
            return factura;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Facturas factura)
        {
            await _facturaService.InsertarFacturaAsync(factura);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Facturas factura)
        {
            factura.FacturaId = id;
            await _facturaService.ActualizarFacturaAsync(factura);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _facturaService.EliminarFacturaAsync(id);
            return Ok();
        }
    }
}
