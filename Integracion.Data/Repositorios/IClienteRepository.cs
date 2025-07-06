using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading.Tasks;
using TiendaVapes.Integracion.Domain;
using TiendaVapes.Integracion.Domain.Entidades;

namespace TiendaVapes.Integracion.Data.Repositorios
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
