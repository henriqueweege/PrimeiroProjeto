using CadastroUsuario.Data.Dto.LogDto;
using CadastroUsuario.Enum;
using CadastroUsuario.Factory.Contracts;

namespace CadastroUsuario.Factory
{
    public class LogFactory : ILogFactory
    {
        public CreateLogDto CriarLog(string log, DateTime data, LogEnum operacao)
        {
            return  new CreateLogDto() { Log=log, Operacao = operacao, DataDaOperacao = data };

        }
    }
}
