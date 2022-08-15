namespace CadastroUsuario.Data.Dto.UsuarioDto
{
    public class ReadUsuarioDto
    {
        public string Id { get; set; }
        private string _firstName { get; set; }
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                if (value == null) throw new FormatException("Valor nome não pode ser nulo");


                foreach (var i in value)
                {
                    if (char.IsDigit(i)) throw new FormatException("Nome não pode conter números.");
                }
                _firstName = value;
            }
        }
        private string? _surName { get; set; }
        public string? SurName
        {
            get
            {
                return _surName;
            }
            set
            {

                if (value != null)
                {
                    foreach (var i in value)
                    {
                        if (char.IsDigit(i)) throw new FormatException("Sobrenome não pode conter números.");
                    }

                }
                _surName = value;
            }
        }
        public int Age { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
