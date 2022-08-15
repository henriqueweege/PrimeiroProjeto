using AutoMapper;
using CadastroUsuario.Data.Dto.LogDto;
using CadastroUsuario.Model;

namespace CadastroUsuario.Profiles
{
    public class LogProfile:Profile
    {
        public LogProfile()
        {
            CreateMap<CreateLogDto, LogModel>();
            CreateMap<LogModel, ReadLogDto>();
        }
    }
}
