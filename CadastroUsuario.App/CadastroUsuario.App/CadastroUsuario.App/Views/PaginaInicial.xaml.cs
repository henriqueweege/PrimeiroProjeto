using CadastroUsuario.App.Dto;
using CadastroUsuario.App.Service;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CadastroUsuario.App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaInicial : ContentPage
    {
        public Command TouchCommand { get; set; }

        public PaginaInicial()
        {
            InitializeComponent();
            BuscarUsuarios();
            TouchCommand = new Command<ReadUsuarioDto>((ReadUsuarioDto user) => Navigation.PushAsync(new MenuDeletarAtualizar(user))); 
            BindingContext = this;

        }

        private void NavegarParaCadastrarNovoUsuario(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CadastrarUsuario());
        }

        public async void BuscarUsuarios()
        {
            var cadastroServices = new CadastroUsuarioServices();
            try
            {
                var usuariosCadastrados = await cadastroServices.BuscarUsuarios();
                 UsuariosCadastrados.ItemsSource = usuariosCadastrados.Select(usuario => new InfosDoUsuario(usuario, TouchCommand));
               // UsuariosCadastrados.ItemsSource = usuariosCadastrados;

            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro ao buscar usuários.", " ", "Ok");

            }
        }
        private async void MenuDeletarAtualizar(object sender, SelectedItemChangedEventArgs e)
        {

            if (e.SelectedItem == null) return;
            var opcoes = new string[2];
            opcoes[0] = "Atualizar";
            opcoes[1] = "Deletar";


            var opcaoEscolhida = await DisplayActionSheet("Escolha a ação desejada.", "Cancelar", " ", opcoes);

            var cadastroServices = new CadastroUsuarioServices();

            if (opcaoEscolhida == "Deletar")
            {
                try
                {
                    var usuarioParaExcluir = (ReadUsuarioDto)e.SelectedItem;

                    var usuarioExcluido = cadastroServices.DeletarUsuario(usuarioParaExcluir.Id).Result;
                    if (usuarioExcluido)
                    {
                        await DisplayAlert("Usuario excluído com sucesso.", " ", "Ok");
                        BuscarUsuarios();

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
            if (opcaoEscolhida == "Atualizar")
            {
                try
                {
                    var usuarioParaAtualizar = (ReadUsuarioDto)e.SelectedItem;
                    Navigation.PushAsync(new AtualizarUsuario(usuarioParaAtualizar));


                }
                catch (Exception ex)
                {
                    await DisplayAlert("Ocorreu um erro ao tentar atualizar o usuário.", " ", "Ok");


                }


            }
            this.UsuariosCadastrados.SelectedItem = null;

        }

        private void Atualizar(object sender, EventArgs e)
        {
            BuscarUsuarios();
            Refresh.IsRefreshing = false;
        }
    }
}