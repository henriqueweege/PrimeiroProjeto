using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroUsuario.App.Dto
{
    public class ReadCadastraUsuarioDto
    {
        public String Id { get; set; }
        public String FirstName { get; set; }
        public String SurName { get; set; }
        public int Age { get; set; }
        public string DataToDisplay {  get { return "                  Nome: " + FirstName + "           Sobrenome: " + SurName + 
                    "           Idade: " + Age; } }
    }
}
