using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

using System.Threading.Tasks;
using TiendaVapes.Core.Domain;
using TiendaVapes.Core.Domain.Entidades;

namespace TiendaVapes.Core.Data.Repositorios
{
    public class InventarioMovimientoRepository : IInventarioMovimientoRepository
    {
        private readonly string connectionString;

        public InventarioMovimientoRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<IEnumerable<InventarioMovimiento>> ObtenerMovimientosAsync()
        {
            var movimientos = new List<InventarioMovimiento>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("ObtenerInventarioMovimientos", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            movimientos.Add(new InventarioMovimiento
                            {
                                MovimientoId = reader.GetInt32(0),
                                ProductoId = reader.GetInt32(1),
                                TipoMovimiento = reader.GetString(2),
                                Cantidad = reader.GetInt32(3),
                                Fecha = reader.GetDateTime(4),
                                UsuarioId = reader.GetInt32(5)
                            });
                        }
                    }
                }
            }

            return movimientos;
        }

        public async Task<InventarioMovimiento> ObtenerMovimientoPorIdAsync(int id)
        {
            InventarioMovimiento movimiento = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("ObtenerInventarioMovimientoPorId", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MovimientoId", id);

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            movimiento = new InventarioMovimiento
                            {
                                MovimientoId = reader.GetInt32(0),
                                ProductoId = reader.GetInt32(1),
                                TipoMovimiento = reader.GetString(2),
                                Cantidad = reader.GetInt32(3),
                                Fecha = reader.GetDateTime(4),
                                UsuarioId = reader.GetInt32(5)
                            };
                        }
                    }
                }
            }

            return movimiento;
        }

        public async Task InsertarMovimientoAsync(InventarioMovimiento movimiento)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("InsertarInventarioMovimiento", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductoId", movimiento.ProductoId);
                    cmd.Parameters.AddWithValue("@TipoMovimiento", movimiento.TipoMovimiento);
                    cmd.Parameters.AddWithValue("@Cantidad", movimiento.Cantidad);
                    cmd.Parameters.AddWithValue("@UsuarioId", movimiento.UsuarioId);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task ActualizarMovimientoAsync(InventarioMovimiento movimiento)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("ActualizarInventarioMovimiento", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MovimientoId", movimiento.MovimientoId);
                    cmd.Parameters.AddWithValue("@TipoMovimiento", movimiento.TipoMovimiento);
                    cmd.Parameters.AddWithValue("@Cantidad", movimiento.Cantidad);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task EliminarMovimientoAsync(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("EliminarInventarioMovimiento", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MovimientoId", id);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
