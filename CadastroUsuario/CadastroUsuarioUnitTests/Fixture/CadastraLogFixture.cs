using AutoMapper;
using CadastroUsuario.Controllers;
using CadastroUsuario.Data;
using CadastroUsuario.Data.Dto.LogDto;
using CadastroUsuario.Data.Repository;
using CadastroUsuario.Data.Repository.Contracts;
using CadastroUsuario.Factory;
using CadastroUsuario.Factory.Contracts;
using CadastroUsuario.Model;
using CadastroUsuario.Services;
using CadastroUsuario.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuarioUnitTests.Fixture
{
    public class CadastraLogFixture : IDisposable
    {
        public ILogServices Services { get; set; }
        public ILogFactory Factory { get; set; }
        public CreateLogDto CreateLogDto { get; set; }
        public LogModel Log { get; set; }

        public IMapper Mapper { get; set; }


        public CadastraLogFixture()
        {
            var servico = new ServiceCollection();
            servico.AddScoped<DataContext, DataContext>();
            servico.AddScoped<LogServices, LogServices>();
            servico.AddScoped<LogRepository, LogRepository>();
            servico.AddScoped<LogFactory, LogFactory>();
            servico.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


            var provedor = servico.BuildServiceProvider();
           
            
            Services = provedor.GetService<LogServices>();
            Factory = provedor.GetService<LogFactory>();
            Mapper = provedor.GetService<IMapper>();

            CreateLogDto = new CreateLogDto()
            {
                Log = "Mensagem",
                Operacao = CadastroUsuario.Enum.LogEnum.Create,
                DataDaOperacao = DateTime.UtcNow
            };

            Log = new LogModel()
            {
                Log = "Mensagem",
                Operacao = CadastroUsuario.Enum.LogEnum.Create,
                DataDaOperacao = DateTime.UtcNow
            };
        }

        public void Dispose()
        {

        }
    }
}
