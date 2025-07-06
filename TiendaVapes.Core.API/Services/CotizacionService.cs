using System.Collections.Generic;
using System.Threading.Tasks;
using TiendaVapes.Core.Data.Repositorios;
using TiendaVapes.Core.Domain;
using TiendaVapes.Core.Domain.Entidades;

namespace TiendaVapes.Core.API.Services
{
    public class CotizacionService : ICotizacionService
    {
        private readonly ICotizacionesRepository _cotizacionesRepository;

        public CotizacionService(ICotizacionesRepository cotizacionesRepository)
        {
            _cotizacionesRepository = cotizacionesRepository;
        }

        public async Task<IEnumerable<Cotizacion>> ObtenerCotizacionesAsync()
        {
            return await _cotizacionesRepository.ObtenerCotizacionesAsync();
        }

        public async Task<Cotizacion> ObtenerCotizacionPorIdAsync(int id)
        {
            return await _cotizacionesRepository.ObtenerCotizacionPorIdAsync(id);
        }

        public async Task InsertarCotizacionAsync(Cotizacion cotizacion)
        {
            await _cotizacionesRepository.InsertarCotizacionAsync(cotizacion);
        }

        public async Task ActualizarCotizacionAsync(Cotizacion cotizacion)
        {
            await _cotizacionesRepository.ActualizarCotizacionAsync(cotizacion);
        }

        public async Task EliminarCotizacionAsync(int id)
        {
            await _cotizacionesRepository.EliminarCotizacionAsync(id);
        }
    }
}
