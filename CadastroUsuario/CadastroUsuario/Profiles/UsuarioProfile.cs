using AutoMapper;
using CadastroUsuario.Data.Dto;
using CadastroUsuario.Model;

namespace CadastroUsuario.Profiles
{
    public class UsuarioProfile:Profile
    {
        public UsuarioProfile()
        {
            CreateMap<CreateUsuarioDto, Usuario>();
            CreateMap<UpdateUsuarioDto, Usuario>();
            CreateMap<Usuario, ReadUsuarioDto > ();
        }
    }
}
