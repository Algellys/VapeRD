using System.Collections.Generic;
using System.Threading.Tasks;
using TiendaVapes.Integracion.Domain.Entidades;

namespace TiendaVapes.Integracion.Services.Interfaces
{
    public interface IServiciosService
    {
        Task<IEnumerable<Servicios>> ObtenerServiciosAsync();
        Task<Servicios> ObtenerServicioPorIdAsync(int id);
        Task InsertarServicioAsync(Servicios servicio);
        Task ActualizarServicioAsync(Servicios servicio);
        Task EliminarServicioAsync(int id);
    }
}
