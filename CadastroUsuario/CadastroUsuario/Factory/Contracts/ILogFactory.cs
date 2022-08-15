using CadastroUsuario.Data.Dto.LogDto;
using CadastroUsuario.Enum;

namespace CadastroUsuario.Factory.Contracts
{
    public interface ILogFactory
    {
        public CreateLogDto CriarLog(string log, DateTime data, LogEnum operacao);
    }
}
