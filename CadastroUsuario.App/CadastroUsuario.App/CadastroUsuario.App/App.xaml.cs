using CadastroUsuario.App.Service;
using CadastroUsuario.App.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CadastroUsuario.App
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            try
            {
                var pagina = new NavigationPage(new PaginaInicial());

                MainPage = pagina;
            }
            catch (Exception ex)
            {
                var x = 0;
            }

        }

        protected override void OnStart()
        {

            

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
