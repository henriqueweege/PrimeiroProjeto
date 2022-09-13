using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CadastroUsuario.App.Dto
{
    public class ReadUsuarioDto
    {
        public String Id { get; set; }

        public String FirstName { get; set; }
    
        public String VisualizacaoNome
        {
            get
            {
                return $"Nome:\n{FirstName}";
            }
        }

        public String SurName { get; set;}

        public String VisualizacaoSobrenome
        {
            get
            {
                return $"Sobrenome:\n{SurName}";
            }
        }
        public int Age { get; set; }

        public String VisualizacaoIdade
        {
            get
            {
                return $"Idade:\n{Age}";
            }
        }
    }
}
