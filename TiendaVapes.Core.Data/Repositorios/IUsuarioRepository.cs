using System.Collections.Generic;
using System.Threading.Tasks;
using TiendaVapes.Core.Domain;
using TiendaVapes.Core.Domain.Entidades;

namespace TiendaVapes.Core.Data.Repositorios
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> ObtenerUsuariosAsync();
        Task<Usuario> ObtenerUsuarioPorIdAsync(int id);
        Task InsertarUsuarioAsync(Usuario usuario);
        Task ActualizarUsuarioAsync(Usuario usuario);
        Task EliminarUsuarioAsync(int id);
    }
}
