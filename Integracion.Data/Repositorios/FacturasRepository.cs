using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

using System.Threading.Tasks;
using System.Threading.Tasks;
using TiendaVapes.Integracion.Domain;
using TiendaVapes.Integracion.Domain.Entidades;

namespace TiendaVapes.Integracion.Data.Repositorios
{
    public class FacturasRepository : IFacturasRepository
    {
        private readonly string connectionString;

        public FacturasRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<IEnumerable<Facturas>> ObtenerFacturasAsync()
        {
            var facturas = new List<Facturas>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("ObtenerFacturas", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            facturas.Add(new Facturas
                            {
                                FacturaId = reader.GetInt32(0),
                                ClienteId = reader.GetInt32(1),
                                Fecha = reader.GetDateTime(2),
                                Total = reader.GetDecimal(3)
                            });
                        }
                    }
                }
            }
            return facturas;
        }

        public async Task<Facturas> ObtenerFacturaPorIdAsync(int id)
        {
            Facturas factura = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("ObtenerFacturaPorId", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FacturaId", id);

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            factura = new Facturas
                            {
                                FacturaId = reader.GetInt32(0),
                                ClienteId = reader.GetInt32(1),
                                Fecha = reader.GetDateTime(2),
                                Total = reader.GetDecimal(3)
                            };
                        }
                    }
                }
            }
            return factura;
        }

        public async Task InsertarFacturaAsync(Facturas factura)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("InsertarFactura", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ClienteId", factura.ClienteId);
                    cmd.Parameters.AddWithValue("@Total", factura.Total);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task ActualizarFacturaAsync(Facturas factura)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("ActualizarFactura", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FacturaId", factura.FacturaId);
                    cmd.Parameters.AddWithValue("@ClienteId", factura.ClienteId);
                    cmd.Parameters.AddWithValue("@Total", factura.Total);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task EliminarFacturaAsync(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("EliminarFactura", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FacturaId", id);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
