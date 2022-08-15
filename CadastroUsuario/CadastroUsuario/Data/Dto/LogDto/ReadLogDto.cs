using CadastroUsuario.Enum;

namespace CadastroUsuario.Data.Dto.LogDto
{
    public class ReadLogDto
    {
        public string Id { get; set; }
        public string Log { get; set; }
        public LogEnum Operacao { get; set; }
        public DateTime DataDaOperacao { get; set; }
    }
}
