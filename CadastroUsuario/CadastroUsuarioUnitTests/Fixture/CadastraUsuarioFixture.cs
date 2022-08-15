using AutoMapper;
using CadastroUsuario.Controllers;
using CadastroUsuario.Data;
using CadastroUsuario.Data.Dto.UsuarioDto;
using CadastroUsuario.Data.Repository;
using CadastroUsuario.Data.Repository.Contracts;
using CadastroUsuario.Model;
using CadastroUsuario.Services;
using CadastroUsuario.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuarioUnitTests.Fixture
{
    public class CadastraUsuarioFixture : IDisposable
    {
        public IUsuarioRepository Repository { get; set; }
        public IUsuarioServices Services { get; set; }
        public UsuarioController Controller { get; set; }
        public CreateUsuarioDto CreateUsuarioDto { get; set; }
        public UpdateUsuarioDto UpdateUsuarioDto { get; set; }
        public UsuarioModel Usuario { get; set; }

        public IMapper Mapper { get; set; }


        public CadastraUsuarioFixture()
        {
            var servico = new ServiceCollection();
            servico.AddScoped<DataContext, DataContext>();
            servico.AddScoped<UsuarioServices, UsuarioServices>();
            servico.AddScoped<UsuarioRepository, UsuarioRepository>();
            servico.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


            var provedor = servico.BuildServiceProvider();

            Repository = provedor.GetService<UsuarioRepository>();
            Services = provedor.GetService<UsuarioServices>();
            Controller = provedor.GetService<UsuarioController>();
            Mapper = provedor.GetService<IMapper>();


            CreateUsuarioDto = new CreateUsuarioDto()
            {
                FirstName = "primeiroNome",
                SurName = "sobrenome",
                Age = 10
            };

            UpdateUsuarioDto = new UpdateUsuarioDto()
            {
                Id = "",
                FirstName = "primeiroNomeModificado",
                SurName = "sobrenome",
                Age = 10
            };

            Usuario = new UsuarioModel()
            {
                FirstName = "primeiroNomeModificado",
                SurName = "sobrenome",
                Age = 10
            };
        }

        public void Dispose()
        {
            
        }
    }
}
