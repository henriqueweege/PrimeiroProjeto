using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroUsuario.App.Dto
{
    public class UpdateUsuarioDto
    {
        public Guid Id { get; set; }
        public String FirstName { get; set; }
        public String SurName { get; set; }
        public int Age { get; set; }
    }
}
