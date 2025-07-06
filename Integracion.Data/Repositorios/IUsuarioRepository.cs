using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading.Tasks;
using TiendaVapes.Integracion.Domain;
using TiendaVapes.Integracion.Domain.Entidades;

namespace TiendaVapes.Integracion.Data.Repositorios
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
