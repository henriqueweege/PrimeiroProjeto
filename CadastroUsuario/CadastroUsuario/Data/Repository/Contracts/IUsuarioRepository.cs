using CadastroUsuario.Data.Dto.UsuarioDto;

namespace CadastroUsuario.Data.Repository.Contracts
{
    public interface IUsuarioRepository
    {
        public ReadUsuarioDto CriarNovoUsuario(CreateUsuarioDto usuarioParaCriar);
        public IEnumerable<ReadUsuarioDto> BuscarTodosOsUsuarios();
        public ReadUsuarioDto BuscarUsuarioPorId(string id);
        public ReadUsuarioDto AtualizarUsuario(UpdateUsuarioDto usuarioParaAtualizar);
        public bool DeletarUsuario(string id);
    }
}
