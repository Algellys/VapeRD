using System.Collections.Generic;
using System.Threading.Tasks;
using TiendaVapes.Core.Domain;
using TiendaVapes.Core.Domain.Entidades;

namespace TiendaVapes.Core.Data.Repositorios
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Clientes>> ObtenerClientesAsync();
        Task<Clientes> ObtenerClientePorIdAsync(int id);
        Task InsertarClienteAsync(Clientes cliente);
        Task ActualizarClienteAsync(Clientes cliente);
        Task EliminarClienteAsync(int id);
    }
}
