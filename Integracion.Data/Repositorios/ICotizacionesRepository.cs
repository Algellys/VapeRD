using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading.Tasks;
using TiendaVapes.Integracion.Domain;
using TiendaVapes.Integracion.Domain.Entidades;

namespace TiendaVapes.Integracion.Data.Repositorios
{
    public interface ICotizacionesRepository
    {
        Task<IEnumerable<Cotizacion>> ObtenerCotizacionesAsync();
        Task<Cotizacion> ObtenerCotizacionPorIdAsync(int id);
        Task InsertarCotizacionAsync(Cotizacion cotizacion);
        Task ActualizarCotizacionAsync(Cotizacion cotizacion);
        Task EliminarCotizacionAsync(int id);
    }
}
