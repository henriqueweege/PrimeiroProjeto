using CadastroUsuario.App.Dto;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CadastroUsuario.App.Service
{
    public class CadastroUsuarioServices
    {
         private readonly HttpClient Client;
        private readonly Uri BaseUrl;
        public CadastroUsuarioServices()
        {
            BaseUrl = new Uri("https://cadastrousuario-api.herokuapp.com/");


            Client = new HttpClient();
            
        }
        public async Task<bool> CadastrarUsuario(CreateUsuarioDto usuarioParaCriar)
        {
            return Client.PostAsJsonAsync($"{BaseUrl}Usuario", usuarioParaCriar).Result.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<ReadUsuarioDto>> BuscarUsuarios()
        {
            try
            {

            var response = await Client.GetAsync($"{BaseUrl}Usuario");

          

            response.EnsureSuccessStatusCode();
            var responseAsList = await response.Content.ReadAsAsync<IEnumerable<ReadUsuarioDto>>();



            return responseAsList;
            }
            catch(Exception ex)
            {
                return new List<ReadUsuarioDto>();
            }

        }

        public async Task<bool> DeletarUsuario(string id)
        {
            var deletar =  Client.DeleteAsync($"{BaseUrl}Usuario/{id}").Result;

            if (deletar.IsSuccessStatusCode)
            {
                Client.Dispose();
                return true;
            }
            return false;

        }

        public async Task<bool> AtualizarUsuario(ReadUsuarioDto usuarioParaAtualizar)
        {
            return Client.PutAsJsonAsync($"{BaseUrl}Usuario/{usuarioParaAtualizar.Id}", usuarioParaAtualizar).Result.IsSuccessStatusCode;

        }
    }
}
