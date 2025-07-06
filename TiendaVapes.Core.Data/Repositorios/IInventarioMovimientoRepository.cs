using System.Collections.Generic;
using System.Threading.Tasks;
using TiendaVapes.Core.Domain;
using TiendaVapes.Core.Domain.Entidades;

namespace TiendaVapes.Core.Data.Repositorios
{
    public interface IInventarioMovimientoRepository
    {
        Task<IEnumerable<InventarioMovimiento>> ObtenerMovimientosAsync();
        Task<InventarioMovimiento> ObtenerMovimientoPorIdAsync(int id);
        Task InsertarMovimientoAsync(InventarioMovimiento movimiento);
        Task ActualizarMovimientoAsync(InventarioMovimiento movimiento);
        Task EliminarMovimientoAsync(int id);
    }
}
