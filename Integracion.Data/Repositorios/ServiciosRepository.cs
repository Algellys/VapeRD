using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

using System.Threading.Tasks;
using System.Threading.Tasks;
using TiendaVapes.Integracion.Domain;
using TiendaVapes.Integracion.Domain.Entidades;

namespace TiendaVapes.Integracion.Data.Repositorios
{
    public class ServiciosRepository : IServiciosRepository
    {
        private readonly string connectionString;

        public ServiciosRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<IEnumerable<Servicios>> ObtenerServiciosAsync()
        {
            var servicios = new List<Servicios>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("ObtenerServicios", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            servicios.Add(new Servicios
                            {
                                ServicioId = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Precio = reader.GetDecimal(2)
                            });
                        }
                    }
                }
            }
            return servicios;
        }

        public async Task<Servicios> ObtenerServicioPorIdAsync(int id)
        {
            Servicios servicio = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("ObtenerServicioPorId", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ServicioId", id);

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            servicio = new Servicios
                            {
                                ServicioId = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Precio = reader.GetDecimal(2)
                            };
                        }
                    }
                }
            }
            return servicio;
        }

        public async Task InsertarServicioAsync(Servicios servicio)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("InsertarServicio", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", servicio.Nombre);
                    cmd.Parameters.AddWithValue("@Precio", servicio.Precio);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task ActualizarServicioAsync(Servicios servicio)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("ActualizarServicio", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ServicioId", servicio.ServicioId);
                    cmd.Parameters.AddWithValue("@Nombre", servicio.Nombre);
                    cmd.Parameters.AddWithValue("@Precio", servicio.Precio);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task EliminarServicioAsync(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("EliminarServicio", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ServicioId", id);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
