using System.Collections.Generic;
using System.Threading.Tasks;
using TiendaVapes.Core.Domain;
using TiendaVapes.Core.Domain.Entidades;

namespace TiendaVapes.Core.Data.Repositorios
{
    public interface IPerfilesRepository
    {
        Task<IEnumerable<Perfiles>> ObtenerPerfilesAsync();
        Task<Perfiles> ObtenerPerfilPorIdAsync(int id);
        Task InsertarPerfilAsync(Perfiles perfil);
        Task ActualizarPerfilAsync(Perfiles perfil);
        Task EliminarPerfilAsync(int id);
    }
}
