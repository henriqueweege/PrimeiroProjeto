using CadastroUsuario.App.Dto;
using CadastroUsuario.App.Service;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CadastroUsuario.App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaInicial : ContentPage
    {
        public Command LongPress { get; }
        public PaginaInicial()
        {
            InitializeComponent();
            BuscarUsuarios();
            LongPress = new Command(() => DisplayAlert(" ", " ", "Ok"));

        }

        private async void NavegarParaAdicionarUsuario(object sender, EventArgs e)
        {

            _ = Navigation.PushAsync(new CadastrarUsuario());

        }

        [Obsolete]
        private void AbrirMenu(object sender, EventArgs e)
        {
            ((MasterDetailPage)App.Current.MainPage).IsPresented = true;
        }

        public async void BuscarUsuarios()
        {
            var cadastroServices = new CadastroUsuarioServices();
            try
            {
                var usuariosCadastrados = await cadastroServices.BuscarUsuarios();
                UsuariosCadastrados.ItemsSource = usuariosCadastrados;
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
                    var usuarioParaExcluir = (ReadCadastraUsuarioDto)e.SelectedItem;

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
                    var usuarioParaAtualizar = (ReadCadastraUsuarioDto)e.SelectedItem;
                    Navigation.PushAsync(new AtualizarUsuario(usuarioParaAtualizar));
                    

                }
                catch (Exception ex)
                {
                    await DisplayAlert("Ocorreu um erro ao tentar atualizar o usuário.", " ", "Ok");
                    

                }


            }
            this.UsuariosCadastrados.SelectedItem = null;

        }

        private void Atualziar(object sender, EventArgs e)
        {
            BuscarUsuarios();
            Refresh.IsRefreshing = false;
        }
    }
}