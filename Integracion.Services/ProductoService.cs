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
    public class ProductoService : IProductoService
    {
        private readonly HttpClient httpClient;
        private readonly ProductoRepository productoRepository;
        private readonly string coreApiUrl = "https://localhost:7189/api/productos";

        public ProductoService(IConfiguration configuration)
        {
            httpClient = new HttpClient();
            string connectionString = configuration.GetConnectionString("BDCore");
            productoRepository = new ProductoRepository(connectionString);
        }

        public async Task<IEnumerable<Productos>> ObtenerProductosAsync()
        {
            try
            {
                var response = await httpClient.GetAsync(coreApiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<IEnumerable<Productos>>(json);
                }
                else
                {
                    return await productoRepository.ObtenerProductosAsync();
                }
            }
            catch (Exception)
            {
                return await productoRepository.ObtenerProductosAsync();
            }
        }

        public async Task<Productos> ObtenerProductoPorIdAsync(int id)
        {
            try
            {
                var response = await httpClient.GetAsync($"{coreApiUrl}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<Productos>(json);
                }
                else
                {
                    return await productoRepository.ObtenerProductoPorIdAsync(id);
                }
            }
            catch (Exception)
            {
                return await productoRepository.ObtenerProductoPorIdAsync(id);
            }
        }

        public async Task InsertarProductoAsync(Productos producto)
        {
            try
            {
                var jsonContent = new StringContent(JsonSerializer.Serialize(producto), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(coreApiUrl, jsonContent);
                if (!response.IsSuccessStatusCode)
                {
                    await productoRepository.InsertarProductoAsync(producto);
                }
            }
            catch (Exception)
            {
                await productoRepository.InsertarProductoAsync(producto);
            }
        }

        public async Task ActualizarProductoAsync(Productos producto)
        {
            try
            {
                var jsonContent = new StringContent(JsonSerializer.Serialize(producto), Encoding.UTF8, "application/json");
                var response = await httpClient.PutAsync($"{coreApiUrl}/{producto.ProductoId}", jsonContent);
                if (!response.IsSuccessStatusCode)
                {
                    await productoRepository.ActualizarProductoAsync(producto);
                }
            }
            catch (Exception)
            {
                await productoRepository.ActualizarProductoAsync(producto);
            }
        }

        public async Task EliminarProductoAsync(int id)
        {
            try
            {
                var response = await httpClient.DeleteAsync($"{coreApiUrl}/{id}");
                if (!response.IsSuccessStatusCode)
                {
                    await productoRepository.EliminarProductoAsync(id);
                }
            }
            catch (Exception)
            {
                await productoRepository.EliminarProductoAsync(id);
            }
        }
    }
}
