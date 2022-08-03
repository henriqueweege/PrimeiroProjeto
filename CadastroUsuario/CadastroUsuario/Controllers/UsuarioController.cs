using CadastroUsuario.Data.Dto;
using CadastroUsuario.Data.Repository;
using CadastroUsuario.Data.Repository.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CadastroUsuario.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController:ControllerBase
    {
        private readonly IUsuarioRepository Repository;
        public UsuarioController(UsuarioRepository repository)
        {
            Repository = repository;
        }
        [HttpPost]
        public ActionResult<ReadUsuarioDto> CriarUsuario(CreateUsuarioDto usuarioParaCriar)
        {
            var usuarioCriado = Repository.CriarNovoUsuario(usuarioParaCriar);
            if (usuarioCriado != null) return Ok(usuarioCriado);
            return NotFound();
        }


        [HttpGet]
        public ActionResult<IEnumerable<ReadUsuarioDto>> BuscarTodosOsUsuarios()
        {
            var usuarios = Repository.BuscarTodosOsUsuarios();
            if (usuarios.Any()) return Ok(usuarios);
            return NotFound();
        }

        [HttpGet("{id}")]
        public ActionResult<ReadUsuarioDto> BuscarUsuarioPorId(string id)
        {
            var usuario = Repository.BuscarUsuarioPorId(id);
            if (usuario != null) return Ok(usuario);
            return NotFound();
        }

        [HttpPut("{id}")]
        public ActionResult<ReadUsuarioDto> AtualizarUsuario(string id, UpdateUsuarioDto usuarioParaAtualizar)
        {
            if (id == usuarioParaAtualizar.Id)
            {
                var usuarioAtualizado = Repository.AtualizarUsuario(usuarioParaAtualizar);
                if (usuarioAtualizado != null) return Ok(usuarioAtualizado);
                return NotFound();

            }
            return BadRequest("Id passado não corresponde ao id do objeto a ser atualizado.");

        }

        [HttpDelete("{id}")]
        public IActionResult DeletarUsuario(string id)
        {
            var usuarioExcluido = Repository.DeletarUsuario(id);
            if (usuarioExcluido) return NoContent();
            return BadRequest();
        }
    }
}
