using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using TiendaVapes.Core.Domain;
using TiendaVapes.Core.Domain.Entidades;

namespace TiendaVapes.Core.Data.Repositorios
{
    public class PerfilesRepository : IPerfilesRepository
    {
        private readonly string connectionString;

        public PerfilesRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<IEnumerable<Perfiles>> ObtenerPerfilesAsync()
        {
            var perfiles = new List<Perfiles>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("ObtenerPerfiles", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            perfiles.Add(new Perfiles
                            {
                                PerfilId = reader.GetInt32(0),
                                Nombre = reader.GetString(1)
                            });
                        }
                    }
                }
            }
            return perfiles;
        }

        public async Task<Perfiles> ObtenerPerfilPorIdAsync(int id)
        {
            Perfiles perfil = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("ObtenerPerfilPorId", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PerfilId", id);

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            perfil = new Perfiles
                            {
                                PerfilId = reader.GetInt32(0),
                                Nombre = reader.GetString(1)
                            };
                        }
                    }
                }
            }
            return perfil;
        }

        public async Task InsertarPerfilAsync(Perfiles perfil)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("InsertarPerfil", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", perfil.Nombre);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task ActualizarPerfilAsync(Perfiles perfil)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("ActualizarPerfil", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PerfilId", perfil.PerfilId);
                    cmd.Parameters.AddWithValue("@Nombre", perfil.Nombre);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task EliminarPerfilAsync(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("EliminarPerfil", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PerfilId", id);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
