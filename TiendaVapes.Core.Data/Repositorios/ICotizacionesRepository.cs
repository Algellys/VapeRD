using System.Collections.Generic;
using System.Threading.Tasks;
using TiendaVapes.Core.Domain;
using TiendaVapes.Core.Domain.Entidades;

namespace TiendaVapes.Core.Data.Repositorios
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
