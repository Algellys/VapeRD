using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TiendaVapes.Integracion.Domain.Entidades;
using TiendaVapes.Integracion.Services.Interfaces;

namespace TiendaVapes.Integracion.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CuentasPorCobrarController : ControllerBase
    {
        private readonly ICuentasPorCobrarService cuentasService;

        public CuentasPorCobrarController(ICuentasPorCobrarService cuentasService)
        {
            this.cuentasService = cuentasService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CuentaPorCobrar>>> Get()
        {
            var cuentas = await cuentasService.ObtenerCuentasPorCobrarAsync();
            return Ok(cuentas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CuentaPorCobrar>> Get(int id)
        {
            var cuenta = await cuentasService.ObtenerCuentaPorCobrarPorIdAsync(id);
            if (cuenta == null)
                return NotFound();

            return Ok(cuenta);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CuentaPorCobrar cuenta)
        {
            await cuentasService.InsertarCuentaPorCobrarAsync(cuenta);
            return Ok(new { mensaje = "Cuenta por cobrar insertada correctamente" });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] CuentaPorCobrar cuenta)
        {
            if (id != cuenta.CuentaPorCobrarId)
                return BadRequest("El ID no coincide");

            await cuentasService.ActualizarCuentaPorCobrarAsync(cuenta);
            return Ok(new { mensaje = "Cuenta por cobrar actualizada correctamente" });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await cuentasService.EliminarCuentaPorCobrarAsync(id);
            return Ok(new { mensaje = "Cuenta por cobrar eliminada correctamente" });
        }
    }
}
