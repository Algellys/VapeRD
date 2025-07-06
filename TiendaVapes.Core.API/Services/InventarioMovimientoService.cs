using System.Collections.Generic;
using System.Threading.Tasks;
using TiendaVapes.Core.Data.Repositorios;
using TiendaVapes.Core.Domain;
using TiendaVapes.Core.Domain.Entidades;

namespace TiendaVapes.Core.API.Services
{
    public class InventarioMovimientoService : IInventarioMovimientoService
    {
        private readonly IInventarioMovimientoRepository _inventarioMovimientoRepository;

        public InventarioMovimientoService(IInventarioMovimientoRepository inventarioMovimientoRepository)
        {
            _inventarioMovimientoRepository = inventarioMovimientoRepository;
        }

        public async Task<IEnumerable<InventarioMovimiento>> ObtenerMovimientosAsync()
        {
            return await _inventarioMovimientoRepository.ObtenerMovimientosAsync();
        }

        public async Task<InventarioMovimiento> ObtenerMovimientoPorIdAsync(int id)
        {
            return await _inventarioMovimientoRepository.ObtenerMovimientoPorIdAsync(id);
        }

        public async Task InsertarMovimientoAsync(InventarioMovimiento movimiento)
        {
            await _inventarioMovimientoRepository.InsertarMovimientoAsync(movimiento);
        }

        public async Task ActualizarMovimientoAsync(InventarioMovimiento movimiento)
        {
            await _inventarioMovimientoRepository.ActualizarMovimientoAsync(movimiento);
        }

        public async Task EliminarMovimientoAsync(int id)
        {
            await _inventarioMovimientoRepository.EliminarMovimientoAsync(id);
        }
    }
}
