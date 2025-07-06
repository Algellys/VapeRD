using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using TiendaVapes.Core.Domain;
using TiendaVapes.Core.Domain.Entidades;

namespace TiendaVapes.Core.Data.Repositorios
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly string connectionString;

        public ProductoRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<IEnumerable<Producto>> ObtenerProductosAsync()
        {
            var productos = new List<Producto>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("ObtenerProductos", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            productos.Add(new Producto
                            {
                                ProductoId = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Precio = reader.GetDecimal(2),
                                Stock = reader.GetInt32(3)
                            });
                        }
                    }
                }
            }

            return productos;
        }

        public async Task<Producto> ObtenerProductoPorIdAsync(int id)
        {
            Producto producto = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("ObtenerProductoPorId", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductoId", id);

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            producto = new Producto
                            {
                                ProductoId = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Precio = reader.GetDecimal(2),
                                Stock = reader.GetInt32(3)
                            };
                        }
                    }
                }
            }

            return producto;
        }

        public async Task InsertarProductoAsync(Producto producto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("InsertarProducto", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
                    cmd.Parameters.AddWithValue("@Precio", producto.Precio);
                    cmd.Parameters.AddWithValue("@Stock", producto.Stock);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task ActualizarProductoAsync(Producto producto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("ActualizarProducto", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductoId", producto.ProductoId);
                    cmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
                    cmd.Parameters.AddWithValue("@Precio", producto.Precio);
                    cmd.Parameters.AddWithValue("@Stock", producto.Stock);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task EliminarProductoAsync(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("EliminarProducto", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductoId", id);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
