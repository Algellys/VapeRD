using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TiendaVapes.Integracion.Domain.Entidades;
using TiendaVapes.Integracion.Services.Interfaces;

namespace TiendaVapes.Integracion.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService clienteService;

        public ClienteController(IClienteService clienteService)
        {
            this.clienteService = clienteService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clientes>>> Get()
        {
            var clientes = await clienteService.ObtenerClientesAsync();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Clientes>> Get(int id)
        {
            var cliente = await clienteService.ObtenerClientePorIdAsync(id);
            if (cliente == null)
                return NotFound();

            return Ok(cliente);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Clientes cliente)
        {
            await clienteService.InsertarClienteAsync(cliente);
            return Ok(new { mensaje = "Cliente insertado correctamente" });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Clientes cliente)
        {
            if (id != cliente.ClienteId)
                return BadRequest("El ID no coincide");

            await clienteService.ActualizarClienteAsync(cliente);
            return Ok(new { mensaje = "Cliente actualizado correctamente" });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await clienteService.EliminarClienteAsync(id);
            return Ok(new { mensaje = "Cliente eliminado correctamente" });
        }
    }
}
