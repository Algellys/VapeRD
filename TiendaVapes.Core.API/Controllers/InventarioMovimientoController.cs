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
    public class InventarioMovimientoController : ControllerBase
    {
        private readonly IInventarioMovimientoService _inventarioMovimientoService;

        public InventarioMovimientoController(IInventarioMovimientoService inventarioMovimientoService)
        {
            _inventarioMovimientoService = inventarioMovimientoService;
        }

        [HttpGet]
        public async Task<IEnumerable<InventarioMovimiento>> Get()
        {
            return await _inventarioMovimientoService.ObtenerMovimientosAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InventarioMovimiento>> Get(int id)
        {
            var movimiento = await _inventarioMovimientoService.ObtenerMovimientoPorIdAsync(id);
            if (movimiento == null)
                return NotFound();
            return movimiento;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] InventarioMovimiento movimiento)
        {
            await _inventarioMovimientoService.InsertarMovimientoAsync(movimiento);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] InventarioMovimiento movimiento)
        {
            movimiento.MovimientoId = id;
            await _inventarioMovimientoService.ActualizarMovimientoAsync(movimiento);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _inventarioMovimientoService.EliminarMovimientoAsync(id);
            return Ok();
        }
    }
}
