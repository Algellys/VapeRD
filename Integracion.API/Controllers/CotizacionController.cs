using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TiendaVapes.Integracion.Domain.Entidades;
using TiendaVapes.Integracion.Services.Interfaces;

namespace TiendaVapes.Integracion.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CotizacionController : ControllerBase
    {
        private readonly ICotizacionService cotizacionService;

        public CotizacionController(ICotizacionService cotizacionService)
        {
            this.cotizacionService = cotizacionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cotizacion>>> Get()
        {
            var cotizaciones = await cotizacionService.ObtenerCotizacionesAsync();
            return Ok(cotizaciones);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cotizacion>> Get(int id)
        {
            var cotizacion = await cotizacionService.ObtenerCotizacionPorIdAsync(id);
            if (cotizacion == null)
                return NotFound();

            return Ok(cotizacion);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Cotizacion cotizacion)
        {
            await cotizacionService.InsertarCotizacionAsync(cotizacion);
            return Ok(new { mensaje = "Cotización insertada correctamente" });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Cotizacion cotizacion)
        {
            if (id != cotizacion.CotizacionId)
                return BadRequest("El ID no coincide");

            await cotizacionService.ActualizarCotizacionAsync(cotizacion);
            return Ok(new { mensaje = "Cotización actualizada correctamente" });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await cotizacionService.EliminarCotizacionAsync(id);
            return Ok(new { mensaje = "Cotización eliminada correctamente" });
        }
    }
}
