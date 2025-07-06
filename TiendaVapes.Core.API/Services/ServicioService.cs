using System.Collections.Generic;
using System.Threading.Tasks;
using TiendaVapes.Core.Data.Repositorios;
using TiendaVapes.Core.Domain;
using TiendaVapes.Core.Domain.Entidades;

namespace TiendaVapes.Core.API.Services
{
    public class ServicioService : IServicioService
    {
        private readonly IServiciosRepository _serviciosRepository;

        public ServicioService(IServiciosRepository serviciosRepository)
        {
            _serviciosRepository = serviciosRepository;
        }

        public async Task<IEnumerable<Servicios>> ObtenerServiciosAsync()
        {
            return await _serviciosRepository.ObtenerServiciosAsync();
        }

        public async Task<Servicios> ObtenerServicioPorIdAsync(int id)
        {
            return await _serviciosRepository.ObtenerServicioPorIdAsync(id);
        }

        public async Task InsertarServicioAsync(Servicios servicio)
        {
            await _serviciosRepository.InsertarServicioAsync(servicio);
        }

        public async Task ActualizarServicioAsync(Servicios servicio)
        {
            await _serviciosRepository.ActualizarServicioAsync(servicio);
        }

        public async Task EliminarServicioAsync(int id)
        {
            await _serviciosRepository.EliminarServicioAsync(id);
        }
    }
}
