using CadastroUsuario.Enum;

namespace CadastroUsuario.Model
{
    public class LogModel
    {
        public string Id { get; private set; } = Guid.NewGuid().ToString();
        public string Log { get; set; }
        public LogEnum Operacao { get; set; } 
        public DateTime DataDaOperacao { get; set; }
    }
}
