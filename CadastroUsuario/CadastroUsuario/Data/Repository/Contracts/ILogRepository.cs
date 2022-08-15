using CadastroUsuario.Data.Dto.LogDto;
using CadastroUsuario.Enum;

namespace CadastroUsuario.Data.Repository.Contracts
{
    public interface ILogRepository
    {
        public ReadLogDto CriarNovoLog(CreateLogDto logParaCriar);
        public IEnumerable<ReadLogDto> BuscarTodosOsLogs();
        public IEnumerable<ReadLogDto> BuscarLogPorOperacao(LogEnum operacao);

    }
}
