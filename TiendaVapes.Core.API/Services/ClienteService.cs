using System.Collections.Generic;
using System.Threading.Tasks;
using TiendaVapes.Core.Data.Repositorios;
using TiendaVapes.Core.Domain;
using TiendaVapes.Core.Domain.Entidades;

namespace TiendaVapes.Core.API.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<IEnumerable<Clientes>> ObtenerClientesAsync()
        {
            return await _clienteRepository.ObtenerClientesAsync();
        }

        public async Task<Clientes> ObtenerClientePorIdAsync(int id)
        {
            return await _clienteRepository.ObtenerClientePorIdAsync(id);
        }

        public async Task InsertarClienteAsync(Clientes cliente)
        {
            await _clienteRepository.InsertarClienteAsync(cliente);
        }

        public async Task ActualizarClienteAsync(Clientes cliente)
        {
            await _clienteRepository.ActualizarClienteAsync(cliente);
        }

        public async Task EliminarClienteAsync(int id)
        {
            await _clienteRepository.EliminarClienteAsync(id);
        }
    }
}
