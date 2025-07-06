using System.Collections.Generic;
using System.Threading.Tasks;
using TiendaVapes.Core.Domain;
using TiendaVapes.Core.Domain.Entidades;

namespace TiendaVapes.Core.Data.Repositorios
{
    public interface IServiciosRepository
    {
        Task<IEnumerable<Servicios>> ObtenerServiciosAsync();
        Task<Servicios> ObtenerServicioPorIdAsync(int id);
        Task InsertarServicioAsync(Servicios servicio);
        Task ActualizarServicioAsync(Servicios servicio);
        Task EliminarServicioAsync(int id);
    }
}
