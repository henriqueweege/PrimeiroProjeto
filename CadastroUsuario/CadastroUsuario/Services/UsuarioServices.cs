using AutoMapper;
using CadastroUsuario.Data.Dto;
using CadastroUsuario.Model;
using CadastroUsuario.Services.Contracts;

namespace CadastroUsuario.Services
{
    public class UsuarioServices : IUsuarioServices
    {
        private readonly IMapper Mapper;
        public UsuarioServices(IMapper mapper)
        {
            Mapper = mapper;
        }
        public Usuario TransformarCreateDtoEmUsuario(CreateUsuarioDto usuarioParaMapear)
        {
            var usuarioMapeado = Mapper.Map<Usuario>(usuarioParaMapear);
            if (usuarioMapeado != null) return usuarioMapeado;

            throw new Exception("Erro no mapeamento.");
        }

        public ReadUsuarioDto TransformarUsuarioEmReadDto(Usuario usuarioParaMapear)
        {
            var usuarioMapeado = Mapper.Map<ReadUsuarioDto>(usuarioParaMapear);
            if (usuarioMapeado != null) return usuarioMapeado;

            throw new Exception("Erro no mapeamento.");
        }

        public Usuario TransformarUpdadeDtoEmUsuario(UpdateUsuarioDto usuarioParaMapear)
        {
            var usuarioMapeado = Mapper.Map<Usuario>(usuarioParaMapear);
            if (usuarioMapeado != null) return usuarioMapeado;

            throw new Exception("Erro no mapeamento.");
        }

    }
}
