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
    public class CuentasPorCobrarController : ControllerBase
    {
        private readonly ICuentasPorCobrarService _cuentasPorCobrarService;

        public CuentasPorCobrarController(ICuentasPorCobrarService cuentasPorCobrarService)
        {
            _cuentasPorCobrarService = cuentasPorCobrarService;
        }

        [HttpGet]
        public async Task<IEnumerable<CuentaPorCobrar>> Get()
        {
            return await _cuentasPorCobrarService.ObtenerCuentasPorCobrarAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CuentaPorCobrar>> Get(int id)
        {
            var cuenta = await _cuentasPorCobrarService.ObtenerCuentaPorCobrarPorIdAsync(id);
            if (cuenta == null)
                return NotFound();
            return cuenta;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CuentaPorCobrar cuenta)
        {
            await _cuentasPorCobrarService.InsertarCuentaPorCobrarAsync(cuenta);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CuentaPorCobrar cuenta)
        {
            cuenta.CuentaPorCobrarId = id;
            await _cuentasPorCobrarService.ActualizarCuentaPorCobrarAsync(cuenta);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _cuentasPorCobrarService.EliminarCuentaPorCobrarAsync(id);
            return Ok();
        }
    }
}
