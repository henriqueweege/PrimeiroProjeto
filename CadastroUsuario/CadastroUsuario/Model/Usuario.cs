using System.ComponentModel.DataAnnotations;

namespace CadastroUsuario.Model
{
    public class Usuario
    {
        [Key]
        public string Id { get; private set; } = Guid.NewGuid().ToString();
        public string FirstName { get; set; }
        public string? SurName { get; set; }
        public int Age { get; set; }
        public DateTime CreationDate { get; private set; } = DateTime.UtcNow;
    }
}
