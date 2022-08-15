using AutoMapper;
using CadastroUsuario.Data.Dto.UsuarioDto;
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
        public UsuarioModel TransformarCreateDtoEmUsuario(CreateUsuarioDto usuarioParaMapear)
        {
            var usuarioMapeado = Mapper.Map<UsuarioModel>(usuarioParaMapear);
            if (usuarioMapeado != null) return usuarioMapeado;

            throw new Exception("Erro no mapeamento.");
        }

        public ReadUsuarioDto TransformarUsuarioEmReadDto(UsuarioModel usuarioParaMapear)
        {
            var usuarioMapeado = Mapper.Map<ReadUsuarioDto>(usuarioParaMapear);
            if (usuarioMapeado != null) return usuarioMapeado;

            throw new Exception("Erro no mapeamento.");
        }

        public UsuarioModel TransformarUpdadeDtoEmUsuario(UpdateUsuarioDto usuarioParaMapear)
        {
            var usuarioMapeado = Mapper.Map<UsuarioModel>(usuarioParaMapear);
            if (usuarioMapeado != null) return usuarioMapeado;

            throw new Exception("Erro no mapeamento.");
        }

    }
}
