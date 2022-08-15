using CadastroUsuario.Data.Dto.LogDto;
using CadastroUsuario.Data.Repository.Contracts;
using CadastroUsuario.Enum;
using CadastroUsuario.Services;
using CadastroUsuario.Services.Contracts;

namespace CadastroUsuario.Data.Repository
{
    public class LogRepository : ILogRepository
    {
        private readonly DataContext Context;
        private readonly ILogServices Services;
        private ILogger<LogRepository> Logger;

        public LogRepository(DataContext context, LogServices services, ILogger<LogRepository> logger)
        {
            Context = context;
            Services = services;
            Logger = logger;
        }
        public IEnumerable<ReadLogDto> BuscarTodosOsLogs()
        {
                 var logs = from log in Context.Log
                           select new ReadLogDto()
                           {
                                Id = log.Id,
                                Log = log.Log,
                                Operacao = log.Operacao,
                                DataDaOperacao =log.DataDaOperacao
                           };
            if (logs.Any())
            {
                return logs;
            }
            return null;
        }

        public IEnumerable<ReadLogDto> BuscarLogPorOperacao(LogEnum operacao)
        {
            var logs = from log in Context.Log
                       where log.Operacao == operacao
                       select new ReadLogDto()
                       {
                           Id = log.Id,
                           Log = log.Log,
                           Operacao = log.Operacao,
                           DataDaOperacao = log.DataDaOperacao
                       };
            if (logs.Any())
            { 
                return logs;
            } 
            
            return null;
        }

        public ReadLogDto CriarNovoLog(CreateLogDto logParaCriar)
        {
            var logMapeado = Services.TransformarCreateDtoEmLog(logParaCriar);
            if (logMapeado != null)
            {

                Context.Log.Add(logMapeado);
                if (Context.SaveChanges() > 0)
                {
                    var logRetorno = Services.TransformarLogEmReadDto(logMapeado);
                    if (logRetorno != null)
                    {
                        Context.ChangeTracker.Clear();
                        Logger.LogInformation("Log criado com sucesso.");
                        return logRetorno;
                    }
                    Logger.LogInformation("Log não criado, erro no mapeamento.");
                    throw new Exception("Erro no mapeamento");
                }
                Logger.LogInformation("Log não criado, erro ao salvar no banco.");
                throw new Exception("Erro ao salvar log no banco.");
            }
            Logger.LogInformation("Log não criado, erro no mapeamento.");
            throw new Exception("Erro no mapeamento");
        }
    }
}
