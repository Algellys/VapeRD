using System.Collections.Generic;
using System.Threading.Tasks;
using TiendaVapes.Core.Data.Repositorios;
using TiendaVapes.Core.Domain;
using TiendaVapes.Core.Domain.Entidades;

namespace TiendaVapes.Core.API.Services
{
    public class FacturaService : IFacturaService
    {
        private readonly IFacturasRepository _facturasRepository;

        public FacturaService(IFacturasRepository facturasRepository)
        {
            _facturasRepository = facturasRepository;
        }

        public async Task<IEnumerable<Facturas>> ObtenerFacturasAsync()
        {
            return await _facturasRepository.ObtenerFacturasAsync();
        }

        public async Task<Facturas> ObtenerFacturaPorIdAsync(int id)
        {
            return await _facturasRepository.ObtenerFacturaPorIdAsync(id);
        }

        public async Task InsertarFacturaAsync(Facturas factura)
        {
            await _facturasRepository.InsertarFacturaAsync(factura);
        }

        public async Task ActualizarFacturaAsync(Facturas factura)
        {
            await _facturasRepository.ActualizarFacturaAsync(factura);
        }

        public async Task EliminarFacturaAsync(int id)
        {
            await _facturasRepository.EliminarFacturaAsync(id);
        }
    }
}
