using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TiendaVapes.Integracion.Domain.Entidades;
using TiendaVapes.Integracion.Services.Interfaces;

namespace TiendaVapes.Integracion.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> Get()
        {
            var usuarios = await usuarioService.ObtenerUsuariosAsync();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> Get(int id)
        {
            var usuario = await usuarioService.ObtenerUsuarioPorIdAsync(id);
            if (usuario == null)
                return NotFound();

            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Usuario usuario)
        {
            await usuarioService.InsertarUsuarioAsync(usuario);
            return Ok(new { mensaje = "Usuario insertado correctamente" });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Usuario usuario)
        {
            if (id != usuario.UsuarioId)
                return BadRequest("El ID no coincide");

            await usuarioService.ActualizarUsuarioAsync(usuario);
            return Ok(new { mensaje = "Usuario actualizado correctamente" });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await usuarioService.EliminarUsuarioAsync(id);
            return Ok(new { mensaje = "Usuario eliminado correctamente" });
        }
    }
}
