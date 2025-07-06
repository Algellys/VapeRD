using System.Collections.Generic;
using System.Threading.Tasks;
using TiendaVapes.Core.Data.Repositorios;
using TiendaVapes.Core.Domain;
using TiendaVapes.Core.Domain.Entidades;

namespace TiendaVapes.Core.API.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoService(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public async Task<IEnumerable<Producto>> ObtenerProductosAsync()
        {
            return await _productoRepository.ObtenerProductosAsync();
        }

        public async Task<Producto> ObtenerProductoPorIdAsync(int id)
        {
            return await _productoRepository.ObtenerProductoPorIdAsync(id);
        }

        public async Task InsertarProductoAsync(Producto producto)
        {
            await _productoRepository.InsertarProductoAsync(producto);
        }

        public async Task ActualizarProductoAsync(Producto producto)
        {
            await _productoRepository.ActualizarProductoAsync(producto);
        }

        public async Task EliminarProductoAsync(int id)
        {
            await _productoRepository.EliminarProductoAsync(id);
        }
    }
}
