using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TiendaVapes.Integracion.Domain.Entidades;
using TiendaVapes.Integracion.Services.Interfaces;

namespace TiendaVapes.Integracion.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiciosController : ControllerBase
    {
        private readonly IServiciosService serviciosService;

        public ServiciosController(IServiciosService serviciosService)
        {
            this.serviciosService = serviciosService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Servicios>>> Get()
        {
            var servicios = await serviciosService.ObtenerServiciosAsync();
            return Ok(servicios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Servicios>> Get(int id)
        {
            var servicio = await serviciosService.ObtenerServicioPorIdAsync(id);
            if (servicio == null)
                return NotFound();

            return Ok(servicio);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Servicios servicio)
        {
            await serviciosService.InsertarServicioAsync(servicio);
            return Ok(new { mensaje = "Servicio insertado correctamente" });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Servicios servicio)
        {
            if (id != servicio.ServicioId)
                return BadRequest("El ID no coincide");

            await serviciosService.ActualizarServicioAsync(servicio);
            return Ok(new { mensaje = "Servicio actualizado correctamente" });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await serviciosService.EliminarServicioAsync(id);
            return Ok(new { mensaje = "Servicio eliminado correctamente" });
        }
    }
}
