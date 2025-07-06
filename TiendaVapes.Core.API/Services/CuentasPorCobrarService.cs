using System.Collections.Generic;
using System.Threading.Tasks;
using TiendaVapes.Core.Data.Repositorios;
using TiendaVapes.Core.Domain;
using TiendaVapes.Core.Domain.Entidades;

namespace TiendaVapes.Core.API.Services
{
    public class CuentasPorCobrarService : ICuentasPorCobrarService
    {
        private readonly ICuentasPorCobrarRepository _cuentasPorCobrarRepository;

        public CuentasPorCobrarService(ICuentasPorCobrarRepository cuentasPorCobrarRepository)
        {
            _cuentasPorCobrarRepository = cuentasPorCobrarRepository;
        }

        public async Task<IEnumerable<CuentaPorCobrar>> ObtenerCuentasPorCobrarAsync()
        {
            return await _cuentasPorCobrarRepository.ObtenerCuentasPorCobrarAsync();
        }

        public async Task<CuentaPorCobrar> ObtenerCuentaPorCobrarPorIdAsync(int id)
        {
            return await _cuentasPorCobrarRepository.ObtenerCuentaPorCobrarPorIdAsync(id);
        }

        public async Task InsertarCuentaPorCobrarAsync(CuentaPorCobrar cuenta)
        {
            await _cuentasPorCobrarRepository.InsertarCuentaPorCobrarAsync(cuenta);
        }

        public async Task ActualizarCuentaPorCobrarAsync(CuentaPorCobrar cuenta)
        {
            await _cuentasPorCobrarRepository.ActualizarCuentaPorCobrarAsync(cuenta);
        }

        public async Task EliminarCuentaPorCobrarAsync(int id)
        {
            await _cuentasPorCobrarRepository.EliminarCuentaPorCobrarAsync(id);
        }
    }
}
