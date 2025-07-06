using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading.Tasks;
using TiendaVapes.Integracion.Domain;
using TiendaVapes.Integracion.Domain.Entidades;

namespace TiendaVapes.Integracion.Data.Repositorios
{
    public interface ILogsRepository
    {
        Task<IEnumerable<Log>> ObtenerLogsAsync();
        Task<Log> ObtenerLogPorIdAsync(int id);
        Task InsertarLogAsync(Log log);
        Task ActualizarLogAsync(Log log);
        Task EliminarLogAsync(int id);
    }
}
