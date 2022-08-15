using CadastroUsuario.Factory.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuarioUnitTests
{
    public class AoCriarNovoCreateLogDto : IClassFixture<CadastraLogFixture>
    {
        private ILogFactory Factory { get; set; }
        public AoCriarNovoCreateLogDto(CadastraLogFixture fixture)
        {
            Factory = fixture.Factory;
        }

        [Fact]
        public void DadoInputCorretoFactoryDeveGerarNovoCreateLogDto()
        {
            //arrange
            var log = "Mensagem";
            var operacao = CadastroUsuario.Enum.LogEnum.Create;
            var dataDaOperacao = DateTime.UtcNow;

            //act

            var factoryResponse = Factory.CriarLog(log, dataDaOperacao, operacao);

            //assert

            Assert.Equal(log, factoryResponse.Log);
            Assert.Equal(operacao, factoryResponse.Operacao);
            Assert.Equal(dataDaOperacao.ToString("d"), factoryResponse.DataDaOperacao.ToString("d"));
        }
    }
}
