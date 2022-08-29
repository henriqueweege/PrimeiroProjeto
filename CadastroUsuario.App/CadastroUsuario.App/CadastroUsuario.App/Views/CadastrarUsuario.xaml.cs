using CadastroUsuario.App.Dto;
using CadastroUsuario.App.Service;
using CadastroUsuario.App.Views;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace CadastroUsuario.App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastrarUsuario : ContentPage
    {
        public CadastrarUsuario()
        {
            InitializeComponent();
        }

        private async void CadastrarUsuarioAsync(object sender, EventArgs e)
        {
            CreateCadastraUsuarioDto usuario = await CriarUsuario();
            if (await EnviarUsuarioParaCadastro(usuario))
            {
                Navigation.PopToRootAsync();
            }

        }

        private async Task<bool> EnviarUsuarioParaCadastro(CreateCadastraUsuarioDto usuario)
        {
            var cadastrarServices = new CadastroUsuarioServices();

            var resposta = cadastrarServices.CadastrarUsuario(usuario);
            if (resposta.Result == true)
            {
                await DisplayAlert("Usuário cadastrado com sucesso.", " ", "Ok");
                return true;
            }
            await DisplayAlert("Erro no cadastrado do usuário.", " ", "Ok");
            return false;
        }

        private async Task<CreateCadastraUsuarioDto> CriarUsuario()
        {
            var usuario = new CreateCadastraUsuarioDto();

            if (String.IsNullOrEmpty(Nome.Text))
            {

                await DisplayAlert("Nome deve ser preenchido.", " ", "Ok");

            }
            else
            {
                usuario.FirstName = Nome.Text;
            }

            if (String.IsNullOrEmpty(Sobrenome.Text))
            {
                usuario.SurName = null;

            }
            else
            {
                usuario.SurName = Sobrenome.Text;
            }
            if (String.IsNullOrEmpty(Idade.Text))
            {

                await DisplayAlert("Idade deve ser preenchida.", " ", "Ok");

            }
            else
            {
                var idadeENumero = Regex.IsMatch(Idade.Text.ToString(), @"^\d+$");
                if (idadeENumero)
                {

                    usuario.Age = Int32.Parse(Idade.Text.ToString());
                }
                else
                {
                    await DisplayAlert("Idade deve conter apenas números.", " ", "Ok");

                }
            }

            return usuario;
        }

        private void Voltar(object sender, EventArgs e)
        { 
            Navigation.PopAsync();
        }
    }
}