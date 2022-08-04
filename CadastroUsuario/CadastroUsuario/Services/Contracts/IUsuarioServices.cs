using CadastroUsuario.Data.Dto;
using CadastroUsuario.Model;

namespace CadastroUsuario.Services.Contracts
{
    public interface IUsuarioServices
    {
        public Usuario TransformarCreateDtoEmUsuario(CreateUsuarioDto usuarioParaMapear);
        public ReadUsuarioDto TransformarUsuarioEmReadDto(Usuario usuarioParaMapear);
        public Usuario TransformarUpdadeDtoEmUsuario(UpdateUsuarioDto usuarioParaMapear);
    }
}
