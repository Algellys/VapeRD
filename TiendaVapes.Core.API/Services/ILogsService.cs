using System.Collections.Generic;
using System.Threading.Tasks;
using TiendaVapes.Core.Domain;
using TiendaVapes.Core.Domain.Entidades;

namespace TiendaVapes.Core.API.Services
{
    public interface ILogsService
    {
        Task<IEnumerable<Log>> ObtenerLogsAsync();
        Task<Log> ObtenerLogPorIdAsync(int id);
        Task InsertarLogAsync(Log log);
        Task ActualizarLogAsync(Log log);
        Task EliminarLogAsync(int id);
    }
}
