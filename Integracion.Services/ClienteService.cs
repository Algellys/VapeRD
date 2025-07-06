using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TiendaVapes.Integracion.Domain.Entidades;
using TiendaVapes.Integracion.Services.Interfaces;
using TiendaVapes.Integracion.Data.Repositorios;
using Microsoft.Extensions.Configuration;

namespace TiendaVapes.Integracion.Services
{
    public class ClienteService : IClienteService
    {
        private readonly HttpClient httpClient;
        private readonly ClienteRepository clienteRepository;
        private readonly string coreApiUrl;

        public ClienteService(IConfiguration configuration)
        {
            httpClient = new HttpClient();
            coreApiUrl = "https://localhost:7189/api/clientes"; // Ajusta URL de tu Core API
            string connectionString = configuration.GetConnectionString("BDCore");
            clienteRepository = new ClienteRepository(connectionString);
        }

        public async Task<IEnumerable<Clientes>> ObtenerClientesAsync()
        {
            try
            {
                var response = await httpClient.GetAsync(coreApiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<IEnumerable<Clientes>>(json);
                }
                else
                {
                    return await clienteRepository.ObtenerClientesAsync();
                }
            }
            catch (Exception)
            {
                return await clienteRepository.ObtenerClientesAsync();
            }
        }

        public async Task<Clientes> ObtenerClientePorIdAsync(int id)
        {
            try
            {
                var response = await httpClient.GetAsync($"{coreApiUrl}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<Clientes>(json);
                }
                else
                {
                    return await clienteRepository.ObtenerClientePorIdAsync(id);
                }
            }
            catch (Exception)
            {
                return await clienteRepository.ObtenerClientePorIdAsync(id);
            }
        }

        public async Task InsertarClienteAsync(Clientes cliente)
        {
            try
            {
                var jsonContent = new StringContent(JsonSerializer.Serialize(cliente), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(coreApiUrl, jsonContent);
                if (!response.IsSuccessStatusCode)
                {
                    await clienteRepository.InsertarClienteAsync(cliente);
                }
            }
            catch (Exception)
            {
                await clienteRepository.InsertarClienteAsync(cliente);
            }
        }

        public async Task ActualizarClienteAsync(Clientes cliente)
        {
            try
            {
                var jsonContent = new StringContent(JsonSerializer.Serialize(cliente), Encoding.UTF8, "application/json");
                var response = await httpClient.PutAsync($"{coreApiUrl}/{cliente.ClienteId}", jsonContent);
                if (!response.IsSuccessStatusCode)
                {
                    await clienteRepository.ActualizarClienteAsync(cliente);
                }
            }
            catch (Exception)
            {
                await clienteRepository.ActualizarClienteAsync(cliente);
            }
        }

        public async Task EliminarClienteAsync(int id)
        {
            try
            {
                var response = await httpClient.DeleteAsync($"{coreApiUrl}/{id}");
                if (!response.IsSuccessStatusCode)
                {
                    await clienteRepository.EliminarClienteAsync(id);
                }
            }
            catch (Exception)
            {
                await clienteRepository.EliminarClienteAsync(id);
            }
        }
    }
}
