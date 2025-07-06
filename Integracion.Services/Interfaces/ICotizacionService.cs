using System.Collections.Generic;
using System.Threading.Tasks;
using TiendaVapes.Integracion.Domain.Entidades;

namespace TiendaVapes.Integracion.Services.Interfaces
{
    public interface ICotizacionService
    {
        Task<IEnumerable<Cotizacion>> ObtenerCotizacionesAsync();
        Task<Cotizacion> ObtenerCotizacionPorIdAsync(int id);
        Task InsertarCotizacionAsync(Cotizacion cotizacion);
        Task ActualizarCotizacionAsync(Cotizacion cotizacion);
        Task EliminarCotizacionAsync(int id);
    }
}
