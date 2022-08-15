using CadastroUsuario.Data.Dto.LogDto;
using CadastroUsuario.Data.Repository;
using CadastroUsuario.Data.Repository.Contracts;
using CadastroUsuario.Enum;
using CadastroUsuario.Factory;
using CadastroUsuario.Factory.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CadastroUsuario.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogController:ControllerBase
    {
        private readonly ILogRepository LogRepository;
        private ILogger<LogController> Logger;
        private readonly ILogFactory LogFactory;
        public LogController(LogRepository repository, 
                            ILogger<LogController> logger,
                            LogFactory logFactory)
        {
            LogRepository = repository;
            Logger = logger;
            LogFactory = logFactory;
        }
        [HttpGet]
        public ActionResult<IEnumerable<ReadLogDto>> BuscarLogs()
        {
            var logs = LogRepository.BuscarTodosOsLogs();
            if (logs.Any())
            {
                Logger.LogInformation("Logs recuperados com sucesso.");
                LogRepository.CriarNovoLog(LogFactory.CriarLog("Logs recuperados com sucesso.", DateTime.UtcNow, Enum.LogEnum.Read));
                return Ok(logs);
            }
            Logger.LogInformation("Logs não recuperados.");
            LogRepository.CriarNovoLog(LogFactory.CriarLog("Logs não recuperados.", DateTime.UtcNow, Enum.LogEnum.Read));
            return NotFound();
        }

        [HttpGet("{operacao}")]
        public ActionResult<ReadLogDto> BuscarLogPorOperacao(LogEnum operacao)
        {
            var log = LogRepository.BuscarLogPorOperacao(operacao);
            if (log != null)
            {
                Logger.LogInformation("Logs recuperados com sucesso.");
                LogRepository.CriarNovoLog(LogFactory.CriarLog("Logs recuperados com sucesso.", DateTime.UtcNow, Enum.LogEnum.Read));
                return Ok(log);
            }
            Logger.LogInformation("Logs não recuperados.");
            LogRepository.CriarNovoLog(LogFactory.CriarLog("Logs não recuperados.", DateTime.UtcNow, Enum.LogEnum.Read));
            return NotFound();
        }
    }
}
