using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading.Tasks;
using TiendaVapes.Integracion.Domain;
using TiendaVapes.Integracion.Domain.Entidades;

namespace TiendaVapes.Integracion.Data.Repositorios
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
