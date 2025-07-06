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
    public class CotizacionService : ICotizacionService
    {
        private readonly HttpClient httpClient;
        private readonly CotizacionesRepository cotizacionRepository;
        private readonly string coreApiUrl;

        public CotizacionService(IConfiguration configuration)
        {
            httpClient = new HttpClient();
            coreApiUrl = "https://localhost:5001/api/cotizaciones"; // Ajusta URL de tu Core API si cambia
            string connectionString = configuration.GetConnectionString("BDCore");
            cotizacionRepository = new CotizacionesRepository(connectionString);
        }

        public async Task<IEnumerable<Cotizacion>> ObtenerCotizacionesAsync()
        {
            try
            {
                var response = await httpClient.GetAsync(coreApiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<IEnumerable<Cotizacion>>(json);
                }
                else
                {
                    return await cotizacionRepository.ObtenerCotizacionesAsync();
                }
            }
            catch (Exception)
            {
                return await cotizacionRepository.ObtenerCotizacionesAsync();
            }
        }

        public async Task<Cotizacion> ObtenerCotizacionPorIdAsync(int id)
        {
            try
            {
                var response = await httpClient.GetAsync($"{coreApiUrl}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<Cotizacion>(json);
                }
                else
                {
                    return await cotizacionRepository.ObtenerCotizacionPorIdAsync(id);
                }
            }
            catch (Exception)
            {
                return await cotizacionRepository.ObtenerCotizacionPorIdAsync(id);
            }
        }

        public async Task InsertarCotizacionAsync(Cotizacion cotizacion)
        {
            try
            {
                var jsonContent = new StringContent(JsonSerializer.Serialize(cotizacion), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(coreApiUrl, jsonContent);
                if (!response.IsSuccessStatusCode)
                {
                    await cotizacionRepository.InsertarCotizacionAsync(cotizacion);
                }
            }
            catch (Exception)
            {
                await cotizacionRepository.InsertarCotizacionAsync(cotizacion);
            }
        }

        public async Task ActualizarCotizacionAsync(Cotizacion cotizacion)
        {
            try
            {
                var jsonContent = new StringContent(JsonSerializer.Serialize(cotizacion), Encoding.UTF8, "application/json");
                var response = await httpClient.PutAsync($"{coreApiUrl}/{cotizacion.CotizacionId}", jsonContent);
                if (!response.IsSuccessStatusCode)
                {
                    await cotizacionRepository.ActualizarCotizacionAsync(cotizacion);
                }
            }
            catch (Exception)
            {
                await cotizacionRepository.ActualizarCotizacionAsync(cotizacion);
            }
        }

        public async Task EliminarCotizacionAsync(int id)
        {
            try
            {
                var response = await httpClient.DeleteAsync($"{coreApiUrl}/{id}");
                if (!response.IsSuccessStatusCode)
                {
                    await cotizacionRepository.EliminarCotizacionAsync(id);
                }
            }
            catch (Exception)
            {
                await cotizacionRepository.EliminarCotizacionAsync(id);
            }
        }
    }
}
