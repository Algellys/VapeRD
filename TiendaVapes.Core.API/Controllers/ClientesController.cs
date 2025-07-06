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
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<IEnumerable<Clientes>> Get()
        {
            return await _clienteService.ObtenerClientesAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Clientes>> Get(int id)
        {
            var cliente = await _clienteService.ObtenerClientePorIdAsync(id);
            if (cliente == null)
                return NotFound();
            return cliente;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Clientes cliente)
        {
            await _clienteService.InsertarClienteAsync(cliente);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Clientes cliente)
        {
            cliente.ClienteId = id;
            await _clienteService.ActualizarClienteAsync(cliente);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _clienteService.EliminarClienteAsync(id);
            return Ok();
        }
    }
}
