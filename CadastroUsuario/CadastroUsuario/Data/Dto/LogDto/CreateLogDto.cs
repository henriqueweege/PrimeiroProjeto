using CadastroUsuario.Enum;

namespace CadastroUsuario.Data.Dto.LogDto
{
    public class CreateLogDto
    {
        public string Log { get; set; }
        public LogEnum Operacao { get; set; }
        public DateTime DataDaOperacao { get; set; }
    }
}
