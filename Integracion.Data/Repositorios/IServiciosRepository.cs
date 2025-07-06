using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading.Tasks;
using TiendaVapes.Integracion.Domain;
using TiendaVapes.Integracion.Domain.Entidades;

namespace TiendaVapes.Integracion.Data.Repositorios
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
