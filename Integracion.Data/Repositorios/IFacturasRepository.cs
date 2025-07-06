using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading.Tasks;
using TiendaVapes.Integracion.Domain;
using TiendaVapes.Integracion.Domain.Entidades;

namespace TiendaVapes.Integracion.Data.Repositorios
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
