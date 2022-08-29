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
    [Obsolete]
    public partial class MenuLateral : MasterDetailPage
    {
        public MenuLateral()
        {
            InitializeComponent();
        }

        private void NavegarParaCadastrarUsuario(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CadastrarUsuario());
            IsPresented = false;
        }
    }
}