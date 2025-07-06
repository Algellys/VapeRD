using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

using System.Threading.Tasks;
using TiendaVapes.Core.Domain;
using TiendaVapes.Core.Domain.Entidades;

namespace TiendaVapes.Core.Data.Repositorios
{
    public class LogsRepository : ILogsRepository
    {
        private readonly string connectionString;

        public LogsRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<IEnumerable<Log>> ObtenerLogsAsync()
        {
            var logs = new List<Log>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("ObtenerLogs", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            logs.Add(new Log
                            {
                                LogId = reader.GetInt32(0),
                                UsuarioId = reader.GetInt32(1),
                                Accion = reader.GetString(2),
                                Descripcion = reader.IsDBNull(3) ? null : reader.GetString(3),
                                Fecha = reader.GetDateTime(4)
                            });
                        }
                    }
                }
            }

            return logs;
        }

        public async Task<Log> ObtenerLogPorIdAsync(int id)
        {
            Log log = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("ObtenerLogPorId", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@LogId", id);

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            log = new Log
                            {
                                LogId = reader.GetInt32(0),
                                UsuarioId = reader.GetInt32(1),
                                Accion = reader.GetString(2),
                                Descripcion = reader.IsDBNull(3) ? null : reader.GetString(3),
                                Fecha = reader.GetDateTime(4)
                            };
                        }
                    }
                }
            }

            return log;
        }

        public async Task InsertarLogAsync(Log log)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("InsertarLog", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UsuarioId", log.UsuarioId);
                    cmd.Parameters.AddWithValue("@Accion", log.Accion);
                    cmd.Parameters.AddWithValue("@Descripcion", (object)log.Descripcion ?? DBNull.Value);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task ActualizarLogAsync(Log log)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("ActualizarLog", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@LogId", log.LogId);
                    cmd.Parameters.AddWithValue("@Accion", log.Accion);
                    cmd.Parameters.AddWithValue("@Descripcion", (object)log.Descripcion ?? DBNull.Value);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task EliminarLogAsync(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("EliminarLog", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@LogId", id);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
