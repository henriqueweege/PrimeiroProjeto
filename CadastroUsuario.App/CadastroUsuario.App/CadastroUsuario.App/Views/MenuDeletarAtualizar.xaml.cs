using CadastroUsuario.App.Dto;
using CadastroUsuario.App.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CadastroUsuario.App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuDeletarAtualizar : ContentPage
    {
        public ReadUsuarioDto Usuario { get; set; }

        public MenuDeletarAtualizar(ReadUsuarioDto usuario)
        {
            Usuario = usuario;
            InitializeComponent();
        }

        private  void AtualizarUsuario(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AtualizarUsuario(Usuario));
             
        }

        private async void DeletarUsuario(object sender, EventArgs e)
        {
            var cadastroServices = new CadastroUsuarioServices();

            try
            {
                var usuarioParaExcluir = Usuario;

                var usuarioExcluido = cadastroServices.DeletarUsuario(usuarioParaExcluir.Id).Result;
                if (usuarioExcluido)
                {
                    await DisplayAlert("Usuario excluído com sucesso.", " ", "Ok");
                    Navigation.PopAsync();

                }
                else
                {
                    await DisplayAlert("Não foi possível excluir o usuário.", " ", "Ok");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("erro.", " ", "Ok");
            }
        }


    }
}