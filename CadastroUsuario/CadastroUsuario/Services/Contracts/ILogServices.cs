using CadastroUsuario.Data.Dto.LogDto;
using CadastroUsuario.Model;

namespace CadastroUsuario.Services.Contracts
{
    public interface ILogServices
    {
        public LogModel TransformarCreateDtoEmLog(CreateLogDto logParaMapear);
        public ReadLogDto TransformarLogEmReadDto(LogModel logParaMapear);
    }
}
