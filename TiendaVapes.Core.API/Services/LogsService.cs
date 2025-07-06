using System.Collections.Generic;
using System.Threading.Tasks;
using TiendaVapes.Core.Data.Repositorios;
using TiendaVapes.Core.Domain;
using TiendaVapes.Core.Domain.Entidades;

namespace TiendaVapes.Core.API.Services
{
    public class LogsService : ILogsService
    {
        private readonly ILogsRepository _logsRepository;

        public LogsService(ILogsRepository logsRepository)
        {
            _logsRepository = logsRepository;
        }

        public async Task<IEnumerable<Log>> ObtenerLogsAsync()
        {
            return await _logsRepository.ObtenerLogsAsync();
        }

        public async Task<Log> ObtenerLogPorIdAsync(int id)
        {
            return await _logsRepository.ObtenerLogPorIdAsync(id);
        }

        public async Task InsertarLogAsync(Log log)
        {
            await _logsRepository.InsertarLogAsync(log);
        }

        public async Task ActualizarLogAsync(Log log)
        {
            await _logsRepository.ActualizarLogAsync(log);
        }

        public async Task EliminarLogAsync(int id)
        {
            await _logsRepository.EliminarLogAsync(id);
        }
    }
}
