using System.Collections.Generic;
using System.Threading.Tasks;
using TiendaVapes.Core.Data.Repositorios;
using TiendaVapes.Core.Domain;
using TiendaVapes.Core.Domain.Entidades;

namespace TiendaVapes.Core.API.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<IEnumerable<Usuario>> ObtenerUsuariosAsync()
        {
            return await _usuarioRepository.ObtenerUsuariosAsync();
        }

        public async Task<Usuario> ObtenerUsuarioPorIdAsync(int id)
        {
            return await _usuarioRepository.ObtenerUsuarioPorIdAsync(id);
        }

        public async Task InsertarUsuarioAsync(Usuario usuario)
        {
            await _usuarioRepository.InsertarUsuarioAsync(usuario);
        }

        public async Task ActualizarUsuarioAsync(Usuario usuario)
        {
            await _usuarioRepository.ActualizarUsuarioAsync(usuario);
        }

        public async Task EliminarUsuarioAsync(int id)
        {
            await _usuarioRepository.EliminarUsuarioAsync(id);
        }
    }
}
