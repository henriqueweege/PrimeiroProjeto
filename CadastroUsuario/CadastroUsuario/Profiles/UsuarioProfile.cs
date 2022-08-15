using AutoMapper;
using CadastroUsuario.Data.Dto.UsuarioDto;
using CadastroUsuario.Model;

namespace CadastroUsuario.Profiles
{
    public class UsuarioProfile:Profile
    {
        public UsuarioProfile()
        {
            CreateMap<CreateUsuarioDto, UsuarioModel>();
            CreateMap<UpdateUsuarioDto, UsuarioModel>();
            CreateMap<UsuarioModel, ReadUsuarioDto > ();
        }
    }
}
