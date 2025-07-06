using System.Collections.Generic;
using System.Threading.Tasks;
using TiendaVapes.Integracion.Domain.Entidades;

namespace TiendaVapes.Integracion.Services.Interfaces
{
    public interface IProductoService
    {
        Task<IEnumerable<Productos>> ObtenerProductosAsync();
        Task<Productos> ObtenerProductoPorIdAsync(int id);
        Task InsertarProductoAsync(Productos producto);
        Task ActualizarProductoAsync(Productos producto);
        Task EliminarProductoAsync(int id);
    }
}
