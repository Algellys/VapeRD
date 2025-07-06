using System.Collections.Generic;
using System.Threading.Tasks;
using TiendaVapes.Core.Domain;
using TiendaVapes.Core.Domain.Entidades;

namespace TiendaVapes.Core.Data.Repositorios
{
    public interface IFacturasRepository
    {
        Task<IEnumerable<Facturas>> ObtenerFacturasAsync();
        Task<Facturas> ObtenerFacturaPorIdAsync(int id);
        Task InsertarFacturaAsync(Facturas factura);
        Task ActualizarFacturaAsync(Facturas factura);
        Task EliminarFacturaAsync(int id);
    }
}
