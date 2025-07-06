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
    public class LogsController : ControllerBase
    {
        private readonly ILogsService _logsService;

        public LogsController(ILogsService logsService)
        {
            _logsService = logsService;
        }

        [HttpGet]
        public async Task<IEnumerable<Log>> Get()
        {
            return await _logsService.ObtenerLogsAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Log>> Get(int id)
        {
            var log = await _logsService.ObtenerLogPorIdAsync(id);
            if (log == null)
                return NotFound();
            return log;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Log log)
        {
            await _logsService.InsertarLogAsync(log);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Log log)
        {
            log.LogId = id;
            await _logsService.ActualizarLogAsync(log);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _logsService.EliminarLogAsync(id);
            return Ok();
        }
    }
}
