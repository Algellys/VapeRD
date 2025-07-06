using System.Collections.Generic;
using System.Threading.Tasks;
using TiendaVapes.Integracion.Domain.Entidades;

namespace TiendaVapes.Integracion.Services.Interfaces
{
    public interface ICuentasPorCobrarService
    {
        Task<IEnumerable<CuentaPorCobrar>> ObtenerCuentasPorCobrarAsync();
        Task<CuentaPorCobrar> ObtenerCuentaPorCobrarPorIdAsync(int id);
        Task InsertarCuentaPorCobrarAsync(CuentaPorCobrar cuenta);
        Task ActualizarCuentaPorCobrarAsync(CuentaPorCobrar cuenta);
        Task EliminarCuentaPorCobrarAsync(int id);
    }
}
