
using System.Collections.Generic;
using System.Threading.Tasks;
using TiendaVapes.Integracion.Domain.Entidades;

namespace TiendaVapes.Integracion.Services.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<Clientes>> ObtenerClientesAsync();
        Task<Clientes> ObtenerClientePorIdAsync(int id);
        Task InsertarClienteAsync(Clientes cliente);
        Task ActualizarClienteAsync(Clientes cliente);
        Task EliminarClienteAsync(int id);
    }
}
