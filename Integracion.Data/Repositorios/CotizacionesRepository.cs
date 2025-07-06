using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

using System.Threading.Tasks;
using System.Threading.Tasks;
using TiendaVapes.Integracion.Domain;
using TiendaVapes.Integracion.Domain.Entidades;

namespace TiendaVapes.Integracion.Data.Repositorios
{
    public class CotizacionesRepository : ICotizacionesRepository
    {
        private readonly string connectionString;

        public CotizacionesRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<IEnumerable<Cotizacion>> ObtenerCotizacionesAsync()
        {
            var cotizaciones = new List<Cotizacion>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("ObtenerCotizaciones", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            cotizaciones.Add(new Cotizacion
                            {
                                CotizacionId = reader.GetInt32(0),
                                ClienteId = reader.GetInt32(1),
                                Fecha = reader.GetDateTime(2)
                            });
                        }
                    }
                }
            }

            return cotizaciones;
        }

        public async Task<Cotizacion> ObtenerCotizacionPorIdAsync(int id)
        {
            Cotizacion cotizacion = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("ObtenerCotizacionPorId", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CotizacionId", id);

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            cotizacion = new Cotizacion
                            {
                                CotizacionId = reader.GetInt32(0),
                                ClienteId = reader.GetInt32(1),
                                Fecha = reader.GetDateTime(2)
                            };
                        }
                    }
                }
            }

            return cotizacion;
        }

        public async Task InsertarCotizacionAsync(Cotizacion cotizacion)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("InsertarCotizacion", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ClienteId", cotizacion.ClienteId);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task ActualizarCotizacionAsync(Cotizacion cotizacion)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("ActualizarCotizacion", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CotizacionId", cotizacion.CotizacionId);
                    cmd.Parameters.AddWithValue("@ClienteId", cotizacion.ClienteId);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task EliminarCotizacionAsync(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("EliminarCotizacion", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CotizacionId", id);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
