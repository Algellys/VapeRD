using System.Collections.Generic;
using System.Threading.Tasks;
using TiendaVapes.Core.Domain;
using TiendaVapes.Core.Domain.Entidades;

namespace TiendaVapes.Core.Data.Repositorios
{
    public interface ICuentasPorCobrarRepository
    {
        Task<IEnumerable<CuentaPorCobrar>> ObtenerCuentasPorCobrarAsync();
        Task<CuentaPorCobrar> ObtenerCuentaPorCobrarPorIdAsync(int id);
        Task InsertarCuentaPorCobrarAsync(CuentaPorCobrar cuenta);
        Task ActualizarCuentaPorCobrarAsync(CuentaPorCobrar cuenta);
        Task EliminarCuentaPorCobrarAsync(int id);
    }
}
