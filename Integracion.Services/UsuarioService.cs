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
    public class UsuarioService : IUsuarioService
    {
        private readonly HttpClient httpClient;
        private readonly UsuarioRepository usuarioRepository;
        private readonly string coreApiUrl;

        public UsuarioService(IConfiguration configuration)
        {
            httpClient = new HttpClient();
            coreApiUrl = "https://localhost:7189/api/usuarios"; // Ajusta URL de tu Core API
            string connectionString = configuration.GetConnectionString("BDCore");
            usuarioRepository = new UsuarioRepository(connectionString);
        }

        public async Task<IEnumerable<Usuario>> ObtenerUsuariosAsync()
        {
            try
            {
                var response = await httpClient.GetAsync(coreApiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<IEnumerable<Usuario>>(json);
                }
                else
                {
                    return await usuarioRepository.ObtenerUsuariosAsync();
                }
            }
            catch (Exception)
            {
                return await usuarioRepository.ObtenerUsuariosAsync();
            }
        }

        public async Task<Usuario> ObtenerUsuarioPorIdAsync(int id)
        {
            try
            {
                var response = await httpClient.GetAsync($"{coreApiUrl}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<Usuario>(json);
                }
                else
                {
                    return await usuarioRepository.ObtenerUsuarioPorIdAsync(id);
                }
            }
            catch (Exception)
            {
                return await usuarioRepository.ObtenerUsuarioPorIdAsync(id);
            }
        }

        public async Task InsertarUsuarioAsync(Usuario usuario)
        {
            try
            {
                var jsonContent = new StringContent(JsonSerializer.Serialize(usuario), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(coreApiUrl, jsonContent);
                if (!response.IsSuccessStatusCode)
                {
                    await usuarioRepository.InsertarUsuarioAsync(usuario);
                }
            }
            catch (Exception)
            {
                await usuarioRepository.InsertarUsuarioAsync(usuario);
            }
        }

        public async Task ActualizarUsuarioAsync(Usuario usuario)
        {
            try
            {
                var jsonContent = new StringContent(JsonSerializer.Serialize(usuario), Encoding.UTF8, "application/json");
                var response = await httpClient.PutAsync($"{coreApiUrl}/{usuario.UsuarioId}", jsonContent);
                if (!response.IsSuccessStatusCode)
                {
                    await usuarioRepository.ActualizarUsuarioAsync(usuario);
                }
            }
            catch (Exception)
            {
                await usuarioRepository.ActualizarUsuarioAsync(usuario);
            }
        }

        public async Task EliminarUsuarioAsync(int id)
        {
            try
            {
                var response = await httpClient.DeleteAsync($"{coreApiUrl}/{id}");
                if (!response.IsSuccessStatusCode)
                {
                    await usuarioRepository.EliminarUsuarioAsync(id);
                }
            }
            catch (Exception)
            {
                await usuarioRepository.EliminarUsuarioAsync(id);
            }
        }
    }
}
