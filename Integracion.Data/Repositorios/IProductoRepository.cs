using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading.Tasks;
using TiendaVapes.Integracion.Domain.Entidades;

namespace TiendaVapes.Integracion.Data.Repositorios
{
    public interface IProductoRepository
    {
        Task<IEnumerable<Productos>> ObtenerProductosAsync();
        Task<Productos> ObtenerProductoPorIdAsync(int id);
        Task InsertarProductoAsync(Productos producto);
        Task ActualizarProductoAsync(Productos producto);
        Task EliminarProductoAsync(int id);
    }
}
