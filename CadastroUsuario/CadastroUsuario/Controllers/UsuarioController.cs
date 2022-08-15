using CadastroUsuario.Data.Dto.UsuarioDto;
using CadastroUsuario.Data.Repository;
using CadastroUsuario.Data.Repository.Contracts;
using CadastroUsuario.Factory;
using CadastroUsuario.Factory.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CadastroUsuario.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository Repository;
        private readonly ILogRepository LogRepository;
        private readonly ILogFactory LogFactory;
        private ILogger<UsuarioController> Logger;
        public UsuarioController(UsuarioRepository repository, 
                                ILogger<UsuarioController> logger, 
                                LogRepository logRepository,
                                LogFactory logFactory)
        {
            Repository = repository;
            Logger = logger;
            LogRepository = logRepository;
            LogFactory = logFactory;
        }

        [HttpPost]
        public ActionResult<ReadUsuarioDto> CriarUsuario(CreateUsuarioDto usuarioParaCriar)
        {
            var usuarioCriado = Repository.CriarNovoUsuario(usuarioParaCriar);
            if (usuarioCriado != null)
            {
                Logger.LogInformation("Usuario criado com sucesso.");
                LogRepository.CriarNovoLog(LogFactory.CriarLog("Usuario criado com sucesso", DateTime.UtcNow, Enum.LogEnum.Create));
                return Ok(usuarioCriado);
            }
            Logger.LogInformation("Usuario não criado.");
            LogRepository.CriarNovoLog(LogFactory.CriarLog("Usuario não criado", DateTime.UtcNow, Enum.LogEnum.Create));
            return NotFound();
        }


        [HttpGet]
        public ActionResult<IEnumerable<ReadUsuarioDto>> BuscarTodosOsUsuarios()
        {
            var usuarios = Repository.BuscarTodosOsUsuarios();
            if (usuarios.Any()) 
            {
                Logger.LogInformation("Usuarios recuperados com sucesso.");
                LogRepository.CriarNovoLog(LogFactory.CriarLog("Usuarios recuperados com sucesso.", DateTime.UtcNow, Enum.LogEnum.Read));
                return Ok(usuarios);
            }
            Logger.LogInformation("Usuarios não recuperados.");
            LogRepository.CriarNovoLog(LogFactory.CriarLog("Usuarios não recuperados.", DateTime.UtcNow, Enum.LogEnum.Read));
            return NotFound();
        }

        [HttpGet("{id}")]
        public ActionResult<ReadUsuarioDto> BuscarUsuarioPorId(string id)
        {
            var usuario = Repository.BuscarUsuarioPorId(id);
            if (usuario != null)
            {
                Logger.LogInformation("Usuario recuperado com sucesso.");
                LogRepository.CriarNovoLog(LogFactory.CriarLog("Usuario recuperado com sucesso.", DateTime.UtcNow, Enum.LogEnum.Read));

                return Ok(usuario);
            }
            Logger.LogInformation("Usuario não recuperado.");
            LogRepository.CriarNovoLog(LogFactory.CriarLog("Usuario não recuperado.", DateTime.UtcNow, Enum.LogEnum.Read));
            return NotFound();
        }

        [HttpPut("{id}")]
        public ActionResult<ReadUsuarioDto> AtualizarUsuario(string id, UpdateUsuarioDto usuarioParaAtualizar)
        {
            if (id == usuarioParaAtualizar.Id)
            {
                var usuarioAtualizado = Repository.AtualizarUsuario(usuarioParaAtualizar);
                if (usuarioAtualizado != null)
                {
                    Logger.LogInformation("Usuario atualizado com sucesso.");
                    LogRepository.CriarNovoLog(LogFactory.CriarLog("Usuario atualizado com sucesso.", DateTime.UtcNow, Enum.LogEnum.Update));
                    return Ok(usuarioAtualizado);
                }
                Logger.LogInformation("Usuario não atualizado.");
                LogRepository.CriarNovoLog(LogFactory.CriarLog("Usuario não atualizado.", DateTime.UtcNow, Enum.LogEnum.Update));
                return NotFound();

            }
            Logger.LogInformation("Usuario não atualizado.");
            LogRepository.CriarNovoLog(LogFactory.CriarLog("Usuario não atualizado.", DateTime.UtcNow, Enum.LogEnum.Update));
            return BadRequest("Id passado não corresponde ao id do objeto a ser atualizado.");

        }

        [HttpDelete("{id}")]
        public IActionResult DeletarUsuario(string id)
        {
            var usuarioExcluido = Repository.DeletarUsuario(id);
            if (usuarioExcluido)
            {
                Logger.LogInformation("Usuario deletado com sucesso.");
                LogRepository.CriarNovoLog(LogFactory.CriarLog("Usuario deletado com sucesso.", DateTime.UtcNow, Enum.LogEnum.Delete));
                return NoContent();
            }
            Logger.LogInformation("Usuario não deletado.");
            LogRepository.CriarNovoLog(LogFactory.CriarLog("Usuario não deletado.", DateTime.UtcNow, Enum.LogEnum.Delete));
            return BadRequest();
        }
    }
}
