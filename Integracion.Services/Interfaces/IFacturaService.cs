using System.Collections.Generic;
using System.Threading.Tasks;
using TiendaVapes.Integracion.Domain.Entidades;

namespace TiendaVapes.Integracion.Services.Interfaces
{
    public interface IFacturaService
    {
        Task<IEnumerable<Facturas>> ObtenerFacturasAsync();
        Task<Facturas> ObtenerFacturaPorIdAsync(int id);
        Task InsertarFacturaAsync(Facturas factura);
        Task ActualizarFacturaAsync(Facturas factura);
        Task EliminarFacturaAsync(int id);
    }
}
