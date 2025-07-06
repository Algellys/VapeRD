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
    public class ServiciosService : IServiciosService
    {
        private readonly HttpClient httpClient;
        private readonly ServiciosRepository serviciosRepository;
        private readonly string coreApiUrl;

        public ServiciosService(IConfiguration configuration)
        {
            httpClient = new HttpClient();
            coreApiUrl = "https://localhost:5001/api/servicios"; // Ajusta URL de tu Core API si cambia
            string connectionString = configuration.GetConnectionString("BDCore");
            serviciosRepository = new ServiciosRepository(connectionString);
        }

        public async Task<IEnumerable<Servicios>> ObtenerServiciosAsync()
        {
            try
            {
                var response = await httpClient.GetAsync(coreApiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<IEnumerable<Servicios>>(json);
                }
                else
                {
                    return await serviciosRepository.ObtenerServiciosAsync();
                }
            }
            catch (Exception)
            {
                return await serviciosRepository.ObtenerServiciosAsync();
            }
        }

        public async Task<Servicios> ObtenerServicioPorIdAsync(int id)
        {
            try
            {
                var response = await httpClient.GetAsync($"{coreApiUrl}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<Servicios>(json);
                }
                else
                {
                    return await serviciosRepository.ObtenerServicioPorIdAsync(id);
                }
            }
            catch (Exception)
            {
                return await serviciosRepository.ObtenerServicioPorIdAsync(id);
            }
        }

        public async Task InsertarServicioAsync(Servicios servicio)
        {
            try
            {
                var jsonContent = new StringContent(JsonSerializer.Serialize(servicio), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(coreApiUrl, jsonContent);
                if (!response.IsSuccessStatusCode)
                {
                    await serviciosRepository.InsertarServicioAsync(servicio);
                }
            }
            catch (Exception)
            {
                await serviciosRepository.InsertarServicioAsync(servicio);
            }
        }

        public async Task ActualizarServicioAsync(Servicios servicio)
        {
            try
            {
                var jsonContent = new StringContent(JsonSerializer.Serialize(servicio), Encoding.UTF8, "application/json");
                var response = await httpClient.PutAsync($"{coreApiUrl}/{servicio.ServicioId}", jsonContent);
                if (!response.IsSuccessStatusCode)
                {
                    await serviciosRepository.ActualizarServicioAsync(servicio);
                }
            }
            catch (Exception)
            {
                await serviciosRepository.ActualizarServicioAsync(servicio);
            }
        }

        public async Task EliminarServicioAsync(int id)
        {
            try
            {
                var response = await httpClient.DeleteAsync($"{coreApiUrl}/{id}");
                if (!response.IsSuccessStatusCode)
                {
                    await serviciosRepository.EliminarServicioAsync(id);
                }
            }
            catch (Exception)
            {
                await serviciosRepository.EliminarServicioAsync(id);
            }
        }
    }
}
