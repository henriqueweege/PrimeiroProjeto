using CadastroUsuario.Data.Dto;
using CadastroUsuario.Data.Repository;
using CadastroUsuario.Data.Repository.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CadastroUsuario.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository Repository;
        private ILogger<UsuarioController> Logger;
        public UsuarioController(UsuarioRepository repository, ILogger<UsuarioController> logger)
        {
            Repository = repository;
            Logger = logger;
        }
        [HttpPost]
        public ActionResult<ReadUsuarioDto> CriarUsuario(CreateUsuarioDto usuarioParaCriar)
        {
            var usuarioCriado = Repository.CriarNovoUsuario(usuarioParaCriar);
            if (usuarioCriado != null)
            {
                Logger.LogInformation("Usuario criado com sucesso.");
                return Ok(usuarioCriado);
            }
            Logger.LogInformation("Usuario não criado.");
            return NotFound();
        }


        [HttpGet]
        public ActionResult<IEnumerable<ReadUsuarioDto>> BuscarTodosOsUsuarios()
        {
            var usuarios = Repository.BuscarTodosOsUsuarios();
            if (usuarios.Any()) 
            {
                Logger.LogInformation("Usuarios recuperados com sucesso.");
                return Ok(usuarios);
            }
            Logger.LogInformation("Usuarios não recuperados.");
            return NotFound();
        }

        [HttpGet("{id}")]
        public ActionResult<ReadUsuarioDto> BuscarUsuarioPorId(string id)
        {
            var usuario = Repository.BuscarUsuarioPorId(id);
            if (usuario != null)
            {
                Logger.LogInformation("Usuario recuperado com sucesso.");
                return Ok(usuario);
            }
            Logger.LogInformation("Usuario não recuperado.");
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
                    return Ok(usuarioAtualizado);
                }
                Logger.LogInformation("Usuario não atualizado.");
                return NotFound();

            }
            Logger.LogInformation("Usuario não atualizado.");
            return BadRequest("Id passado não corresponde ao id do objeto a ser atualizado.");

        }

        [HttpDelete("{id}")]
        public IActionResult DeletarUsuario(string id)
        {
            var usuarioExcluido = Repository.DeletarUsuario(id);
            if (usuarioExcluido)
            {
                Logger.LogInformation("Usuario deletado com sucesso.");
                return NoContent();
            }
            Logger.LogInformation("Usuario não deletado.");
            return BadRequest();
        }
    }
}
