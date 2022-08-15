using CadastroUsuario.Data.Dto.UsuarioDto;
using CadastroUsuario.Model;

namespace CadastroUsuario.Services.Contracts
{
    public interface IUsuarioServices
    {
        public UsuarioModel TransformarCreateDtoEmUsuario(CreateUsuarioDto usuarioParaMapear);
        public ReadUsuarioDto TransformarUsuarioEmReadDto(UsuarioModel usuarioParaMapear);
        public UsuarioModel TransformarUpdadeDtoEmUsuario(UpdateUsuarioDto usuarioParaMapear);
    }
}
