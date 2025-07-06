using System.Collections.Generic;
using System.Threading.Tasks;
using TiendaVapes.Core.Domain;
using TiendaVapes.Core.Domain.Entidades;

namespace TiendaVapes.Core.API.Services
{
    public interface IServicioService
    {
        Task<IEnumerable<Servicios>> ObtenerServiciosAsync();
        Task<Servicios> ObtenerServicioPorIdAsync(int id);
        Task InsertarServicioAsync(Servicios servicio);
        Task ActualizarServicioAsync(Servicios servicio);
        Task EliminarServicioAsync(int id);
    }
}
