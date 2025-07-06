using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

using System.Threading.Tasks;
using TiendaVapes.Integracion.Domain;
using TiendaVapes.Integracion.Domain.Entidades;

namespace TiendaVapes.Integracion.Data.Repositorios
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly string connectionString;

        public ClienteRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<IEnumerable<Clientes>> ObtenerClientesAsync()
        {
            var clientes = new List<Clientes>();

            using (Microsoft.Data.SqlClient.SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("ObtenerClientes", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            clientes.Add(new Clientes
                            {
                                ClienteId = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Documento = reader.IsDBNull(2) ? null : reader.GetString(2)
                            });
                        }
                    }
                }
            }
            return clientes;
        }

        public async Task<Clientes> ObtenerClientePorIdAsync(int id)
        {
            Clientes cliente = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("ObtenerClientePorId", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ClienteId", id);

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            cliente = new Clientes
                            {
                                ClienteId = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Documento = reader.IsDBNull(2) ? null : reader.GetString(2)
                            };
                        }
                    }
                }
            }
            return cliente;
        }

        public async Task InsertarClienteAsync(Clientes cliente)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("InsertarCliente", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                    cmd.Parameters.AddWithValue("@Documento", (object)cliente.Documento ?? DBNull.Value);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task ActualizarClienteAsync(Clientes cliente)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("ActualizarCliente", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ClienteId", cliente.ClienteId);
                    cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                    cmd.Parameters.AddWithValue("@Documento", (object)cliente.Documento ?? DBNull.Value);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task EliminarClienteAsync(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("EliminarCliente", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ClienteId", id);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
