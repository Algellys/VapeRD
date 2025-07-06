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
    public class FacturaService : IFacturaService
    {
        private readonly HttpClient httpClient;
        private readonly FacturasRepository facturasRepository;
        private readonly string coreApiUrl;

        public FacturaService(IConfiguration configuration)
        {
            httpClient = new HttpClient();
            coreApiUrl = "https://localhost:7189/api/facturas"; // Puerto Core API configurado
            string connectionString = configuration.GetConnectionString("BDCore");
            facturasRepository = new FacturasRepository(connectionString);
        }

        public async Task<IEnumerable<Facturas>> ObtenerFacturasAsync()
        {
            try
            {
                var response = await httpClient.GetAsync(coreApiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<IEnumerable<Facturas>>(json);
                }
                else
                {
                    return await facturasRepository.ObtenerFacturasAsync();
                }
            }
            catch (Exception)
            {
                return await facturasRepository.ObtenerFacturasAsync();
            }
        }

        public async Task<Facturas> ObtenerFacturaPorIdAsync(int id)
        {
            try
            {
                var response = await httpClient.GetAsync($"{coreApiUrl}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<Facturas>(json);
                }
                else
                {
                    return await facturasRepository.ObtenerFacturaPorIdAsync(id);
                }
            }
            catch (Exception)
            {
                return await facturasRepository.ObtenerFacturaPorIdAsync(id);
            }
        }

        public async Task InsertarFacturaAsync(Facturas factura)
        {
            try
            {
                var jsonContent = new StringContent(JsonSerializer.Serialize(factura), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(coreApiUrl, jsonContent);
                if (!response.IsSuccessStatusCode)
                {
                    await facturasRepository.InsertarFacturaAsync(factura);
                }
            }
            catch (Exception)
            {
                await facturasRepository.InsertarFacturaAsync(factura);
            }
        }

        public async Task ActualizarFacturaAsync(Facturas factura)
        {
            try
            {
                var jsonContent = new StringContent(JsonSerializer.Serialize(factura), Encoding.UTF8, "application/json");
                var response = await httpClient.PutAsync($"{coreApiUrl}/{factura.FacturaId}", jsonContent);
                if (!response.IsSuccessStatusCode)
                {
                    await facturasRepository.ActualizarFacturaAsync(factura);
                }
            }
            catch (Exception)
            {
                await facturasRepository.ActualizarFacturaAsync(factura);
            }
        }

        public async Task EliminarFacturaAsync(int id)
        {
            try
            {
                var response = await httpClient.DeleteAsync($"{coreApiUrl}/{id}");
                if (!response.IsSuccessStatusCode)
                {
                    await facturasRepository.EliminarFacturaAsync(id);
                }
            }
            catch (Exception)
            {
                await facturasRepository.EliminarFacturaAsync(id);
            }
        }
    }
}
