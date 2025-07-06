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
    public class CotizacionesController : ControllerBase
    {
        private readonly ICotizacionService _cotizacionService;

        public CotizacionesController(ICotizacionService cotizacionService)
        {
            _cotizacionService = cotizacionService;
        }

        [HttpGet]
        public async Task<IEnumerable<Cotizacion>> Get()
        {
            return await _cotizacionService.ObtenerCotizacionesAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cotizacion>> Get(int id)
        {
            var cotizacion = await _cotizacionService.ObtenerCotizacionPorIdAsync(id);
            if (cotizacion == null)
                return NotFound();
            return cotizacion;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Cotizacion cotizacion)
        {
            await _cotizacionService.InsertarCotizacionAsync(cotizacion);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Cotizacion cotizacion)
        {
            cotizacion.CotizacionId = id;
            await _cotizacionService.ActualizarCotizacionAsync(cotizacion);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _cotizacionService.EliminarCotizacionAsync(id);
            return Ok();
        }
    }
}
