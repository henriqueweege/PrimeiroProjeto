using CadastroUsuario.Data.Dto.LogDto;
using CadastroUsuario.Model;
using CadastroUsuario.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuarioUnitTests
{
    public class AoMapearLog:IClassFixture<CadastraLogFixture>
    {
        private readonly ILogServices Services;

        private readonly CreateLogDto CreateDto;
        private readonly LogModel Log;


        public AoMapearLog(CadastraLogFixture fixture)
        {
            Services = fixture.Services;
            CreateDto = fixture.CreateLogDto;
            Log = fixture.Log;

        }

        [Fact]
        public void DadoCreateDtoEntidadeDeveSerMapeadaParaLog()
        {
            //arrange
            //act
            var entidadeMapeada = Services.TransformarCreateDtoEmLog(CreateDto);

            //assert
            Assert.IsType<LogModel>(entidadeMapeada);
        }

        

        [Fact]
        public void DadoLogEntidadeDeveSerMapeadaParaReadDto()
        {
            //arrange
            //act
            var entidadeMapeada = Services.TransformarLogEmReadDto(Log);

            //assert
            Assert.IsType<ReadLogDto>(entidadeMapeada);
        }
    }
}
