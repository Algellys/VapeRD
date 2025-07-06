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
    public class ServiciosController : ControllerBase
    {
        private readonly IServicioService _servicioService;

        public ServiciosController(IServicioService servicioService)
        {
            _servicioService = servicioService;
        }

        [HttpGet]
        public async Task<IEnumerable<Servicios>> Get()
        {
            return await _servicioService.ObtenerServiciosAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Servicios>> Get(int id)
        {
            var servicio = await _servicioService.ObtenerServicioPorIdAsync(id);
            if (servicio == null)
                return NotFound();
            return servicio;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Servicios servicio)
        {
            await _servicioService.InsertarServicioAsync(servicio);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Servicios servicio)
        {
            servicio.ServicioId = id;
            await _servicioService.ActualizarServicioAsync(servicio);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _servicioService.EliminarServicioAsync(id);
            return Ok();
        }
    }
}
