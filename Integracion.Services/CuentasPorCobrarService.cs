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
    public class CuentasPorCobrarService : ICuentasPorCobrarService
    {
        private readonly HttpClient httpClient;
        private readonly CuentasPorCobrarRepository cuentasRepository;
        private readonly string coreApiUrl;

        public CuentasPorCobrarService(IConfiguration configuration)
        {
            httpClient = new HttpClient();
            coreApiUrl = "https://localhost:5001/api/cuentasporcobrar"; // Ajusta URL de tu Core API si cambia
            string connectionString = configuration.GetConnectionString("BDCore");
            cuentasRepository = new CuentasPorCobrarRepository(connectionString);
        }

        public async Task<IEnumerable<CuentaPorCobrar>> ObtenerCuentasPorCobrarAsync()
        {
            try
            {
                var response = await httpClient.GetAsync(coreApiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<IEnumerable<CuentaPorCobrar>>(json);
                }
                else
                {
                    return await cuentasRepository.ObtenerCuentasPorCobrarAsync();
                }
            }
            catch (Exception)
            {
                return await cuentasRepository.ObtenerCuentasPorCobrarAsync();
            }
        }

        public async Task<CuentaPorCobrar> ObtenerCuentaPorCobrarPorIdAsync(int id)
        {
            try
            {
                var response = await httpClient.GetAsync($"{coreApiUrl}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<CuentaPorCobrar>(json);
                }
                else
                {
                    return await cuentasRepository.ObtenerCuentaPorCobrarPorIdAsync(id);
                }
            }
            catch (Exception)
            {
                return await cuentasRepository.ObtenerCuentaPorCobrarPorIdAsync(id);
            }
        }

        public async Task InsertarCuentaPorCobrarAsync(CuentaPorCobrar cuenta)
        {
            try
            {
                var jsonContent = new StringContent(JsonSerializer.Serialize(cuenta), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(coreApiUrl, jsonContent);
                if (!response.IsSuccessStatusCode)
                {
                    await cuentasRepository.InsertarCuentaPorCobrarAsync(cuenta);
                }
            }
            catch (Exception)
            {
                await cuentasRepository.InsertarCuentaPorCobrarAsync(cuenta);
            }
        }

        public async Task ActualizarCuentaPorCobrarAsync(CuentaPorCobrar cuenta)
        {
            try
            {
                var jsonContent = new StringContent(JsonSerializer.Serialize(cuenta), Encoding.UTF8, "application/json");
                var response = await httpClient.PutAsync($"{coreApiUrl}/{cuenta.CuentaPorCobrarId}", jsonContent);
                if (!response.IsSuccessStatusCode)
                {
                    await cuentasRepository.ActualizarCuentaPorCobrarAsync(cuenta);
                }
            }
            catch (Exception)
            {
                await cuentasRepository.ActualizarCuentaPorCobrarAsync(cuenta);
            }
        }

        public async Task EliminarCuentaPorCobrarAsync(int id)
        {
            try
            {
                var response = await httpClient.DeleteAsync($"{coreApiUrl}/{id}");
                if (!response.IsSuccessStatusCode)
                {
                    await cuentasRepository.EliminarCuentaPorCobrarAsync(id);
                }
            }
            catch (Exception)
            {
                await cuentasRepository.EliminarCuentaPorCobrarAsync(id);
            }
        }
    }
}
