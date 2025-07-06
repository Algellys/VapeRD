using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

using System.Threading.Tasks;
using System.Threading.Tasks;
using TiendaVapes.Integracion.Domain;
using TiendaVapes.Integracion.Domain.Entidades;

namespace TiendaVapes.Integracion.Data.Repositorios
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly string connectionString;

        public UsuarioRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<IEnumerable<Usuario>> ObtenerUsuariosAsync()
        {
            var usuarios = new List<Usuario>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("ObtenerUsuarios", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            usuarios.Add(new Usuario
                            {
                                UsuarioId = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Clave = reader.GetString(2),
                                PerfilId = reader.GetInt32(3)
                            });
                        }
                    }
                }
            }

            return usuarios;
        }

        public async Task<Usuario> ObtenerUsuarioPorIdAsync(int id)
        {
            Usuario usuario = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("ObtenerUsuarioPorId", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UsuarioId", id);

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            usuario = new Usuario
                            {
                                UsuarioId = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Clave = reader.GetString(2),
                                PerfilId = reader.GetInt32(3)
                            };
                        }
                    }
                }
            }

            return usuario;
        }

        public async Task InsertarUsuarioAsync(Usuario usuario)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("InsertarUsuario", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    cmd.Parameters.AddWithValue("@Clave", usuario.Clave);
                    cmd.Parameters.AddWithValue("@PerfilId", usuario.PerfilId);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task ActualizarUsuarioAsync(Usuario usuario)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("ActualizarUsuario", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UsuarioId", usuario.UsuarioId);
                    cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    cmd.Parameters.AddWithValue("@Clave", usuario.Clave);
                    cmd.Parameters.AddWithValue("@PerfilId", usuario.PerfilId);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task EliminarUsuarioAsync(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("EliminarUsuario", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UsuarioId", id);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
