using AutoMapper;
using CadastroUsuario.Data.Dto.LogDto;
using CadastroUsuario.Model;
using CadastroUsuario.Services.Contracts;

namespace CadastroUsuario.Services
{
    public class LogServices : ILogServices
    {
        private readonly IMapper Mapper;
        public LogServices(IMapper mapper)
        {
            Mapper = mapper;
        }
        public LogModel TransformarCreateDtoEmLog(CreateLogDto logParaMapear)
        {
            var logMapeado = Mapper.Map<LogModel>(logParaMapear);
            if (logMapeado != null) return logMapeado;

            throw new Exception("Erro no mapeamento.");
        }

        public ReadLogDto TransformarLogEmReadDto(LogModel logParaMapear)
        {
            var logMapeado = Mapper.Map<ReadLogDto>(logParaMapear);
            if (logMapeado != null) return logMapeado;

            throw new Exception("Erro no mapeamento.");
        }
    }
}
