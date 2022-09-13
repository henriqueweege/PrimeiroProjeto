using CadastroUsuario.App.Dto;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CadastroUsuario.App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InfosDoUsuario : ViewCell
    {

        public ReadUsuarioDto Usuario { get; set; }
        public Command TouchCommand { get; set; }

        public InfosDoUsuario()
        {
            InitializeComponent();
        }

        public InfosDoUsuario(ReadUsuarioDto usuario, Command comando)
        {
            Usuario = usuario;
            TouchCommand = comando; 
            InitializeComponent();
        }
    }
}