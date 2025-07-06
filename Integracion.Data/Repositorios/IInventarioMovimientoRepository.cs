using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading.Tasks;
using TiendaVapes.Integracion.Domain;
using TiendaVapes.Integracion.Domain.Entidades;

namespace TiendaVapes.Integracion.Data.Repositorios
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
