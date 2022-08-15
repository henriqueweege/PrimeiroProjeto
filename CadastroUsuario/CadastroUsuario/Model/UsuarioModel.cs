using System.ComponentModel.DataAnnotations;

namespace CadastroUsuario.Model
{
    public class UsuarioModel
    {
        [Key]
        public string Id { get; private set; } = Guid.NewGuid().ToString();
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
        private string? _lastName { get; set; }
        public string? SurName
        {
            get
            {
                return _lastName;
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
                _lastName = value;
            }
        }
        public int Age { get; set; }
        public DateTime CreationDate { get; private set; } = DateTime.UtcNow;
    }
}
