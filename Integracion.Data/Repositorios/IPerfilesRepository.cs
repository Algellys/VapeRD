using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading.Tasks;
using TiendaVapes.Integracion.Domain;
using TiendaVapes.Integracion.Domain.Entidades;

namespace TiendaVapes.Integracion.Data.Repositorios
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
