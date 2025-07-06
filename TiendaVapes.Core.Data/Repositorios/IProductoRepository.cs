using System.Collections.Generic;
using System.Threading.Tasks;
using TiendaVapes.Core.Domain.Entidades;

namespace TiendaVapes.Core.Data.Repositorios
{
    public interface IProductoRepository
    {
        Task<IEnumerable<Producto>> ObtenerProductosAsync();
        Task<Producto> ObtenerProductoPorIdAsync(int id);
        Task InsertarProductoAsync(Producto producto);
        Task ActualizarProductoAsync(Producto producto);
        Task EliminarProductoAsync(int id);
    }
}
