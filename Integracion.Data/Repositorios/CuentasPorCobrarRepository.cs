using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

using System.Threading.Tasks;
using System.Threading.Tasks;
using TiendaVapes.Integracion.Domain;
using TiendaVapes.Integracion.Domain.Entidades;

namespace TiendaVapes.Integracion.Data.Repositorios
{
    public class CuentasPorCobrarRepository : ICuentasPorCobrarRepository
    {
        private readonly string connectionString;

        public CuentasPorCobrarRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<IEnumerable<CuentaPorCobrar>> ObtenerCuentasPorCobrarAsync()
        {
            var cuentas = new List<CuentaPorCobrar>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("ObtenerCuentasPorCobrar", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            cuentas.Add(new CuentaPorCobrar
                            {
                                CuentaPorCobrarId = reader.GetInt32(0),
                                ClienteId = reader.GetInt32(1),
                                Monto = reader.GetDecimal(2),
                                Fecha = reader.GetDateTime(3)
                            });
                        }
                    }
                }
            }

            return cuentas;
        }

        public async Task<CuentaPorCobrar> ObtenerCuentaPorCobrarPorIdAsync(int id)
        {
            CuentaPorCobrar cuenta = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("ObtenerCuentaPorCobrarPorId", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CuentaPorCobrarId", id);

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            cuenta = new CuentaPorCobrar
                            {
                                CuentaPorCobrarId = reader.GetInt32(0),
                                ClienteId = reader.GetInt32(1),
                                Monto = reader.GetDecimal(2),
                                Fecha = reader.GetDateTime(3)
                            };
                        }
                    }
                }
            }

            return cuenta;
        }

        public async Task InsertarCuentaPorCobrarAsync(CuentaPorCobrar cuenta)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("InsertarCuentaPorCobrar", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ClienteId", cuenta.ClienteId);
                    cmd.Parameters.AddWithValue("@Monto", cuenta.Monto);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task ActualizarCuentaPorCobrarAsync(CuentaPorCobrar cuenta)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("ActualizarCuentaPorCobrar", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CuentaPorCobrarId", cuenta.CuentaPorCobrarId);
                    cmd.Parameters.AddWithValue("@ClienteId", cuenta.ClienteId);
                    cmd.Parameters.AddWithValue("@Monto", cuenta.Monto);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task EliminarCuentaPorCobrarAsync(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("EliminarCuentaPorCobrar", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CuentaPorCobrarId", id);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
