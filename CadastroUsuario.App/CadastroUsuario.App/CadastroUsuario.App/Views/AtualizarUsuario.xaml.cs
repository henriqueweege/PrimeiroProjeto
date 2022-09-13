using CadastroUsuario.App.Dto;
using CadastroUsuario.App.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CadastroUsuario.App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AtualizarUsuario : ContentPage
    {
        public ReadUsuarioDto UsuarioParaAtualizar { get; set; }
        public AtualizarUsuario(ReadUsuarioDto usuarioParaAtualizar)
        {
            InitializeComponent();
            UsuarioParaAtualizar = usuarioParaAtualizar;
        }

        private async void AtualizarUsuarioAsync(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Nome.Text))
            {
                UsuarioParaAtualizar.FirstName = Nome.Text;
            }
            if (!String.IsNullOrEmpty(Sobrenome.Text))
            {
                UsuarioParaAtualizar.SurName = Sobrenome.Text;
            }
            if (!String.IsNullOrEmpty(Idade.Text))
            {
                var idadeENumero = Regex.IsMatch(Idade.Text.ToString(), @"^\d+$");
                if (idadeENumero)
                {

                    UsuarioParaAtualizar.Age = Int32.Parse(Idade.Text.ToString());
                }
                else
                {
                    await DisplayAlert("Idade deve conter apenas números.", " ", "Ok");

                }
              
            }
            bool atualizado = EnviarUsuarioParaAtualizar(UsuarioParaAtualizar).Result;
            if (atualizado)
            {
                await DisplayAlert("Usuário atualizado com sucesso.", " ", "Ok");
                Navigation.PopToRootAsync();
                return;

            }
            await DisplayAlert("Erro ao atualizar usuário.", " ", "Ok");

        }

        private async Task<bool> EnviarUsuarioParaAtualizar(ReadUsuarioDto usuarioParaAtualizar)
        {
            var cadastrarServices = new CadastroUsuarioServices();
            var atualizado = false;
            try
            {

             atualizado = cadastrarServices.AtualizarUsuario(UsuarioParaAtualizar).Result;
            }catch(Exception ex)
            {
                    await DisplayAlert("erro.", " ", "Ok");

            }
            if (atualizado) return true;
            return false;
        }
        

    }
}