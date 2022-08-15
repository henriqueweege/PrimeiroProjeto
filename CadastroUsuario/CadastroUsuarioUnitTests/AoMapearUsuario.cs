using AutoMapper;
using CadastroUsuario.Data.Dto.UsuarioDto;
using CadastroUsuario.Model;
using CadastroUsuario.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuarioUnitTests
{
    public class AoMapearUsuario: IClassFixture<CadastraUsuarioFixture>
    {
        private readonly IUsuarioServices Services;

        private readonly CreateUsuarioDto CreateDto;
        private readonly UpdateUsuarioDto UpdateDto;
        private readonly UsuarioModel Usuario;


        public AoMapearUsuario(CadastraUsuarioFixture fixture)
        {
            Services = fixture.Services;
            CreateDto = fixture.CreateUsuarioDto;
            UpdateDto = fixture.UpdateUsuarioDto;
            Usuario = fixture.Usuario;

        }

        [Fact]
        public void DadoCreateDtoEntidadeDeveSerMapeadaParaUsuario()
        {
            //arrange
            //act
            var entidadeMapeada = Services.TransformarCreateDtoEmUsuario(CreateDto);

            //assert
            Assert.IsType<UsuarioModel>(entidadeMapeada);
        }

        [Fact]
        public void DadoUpdateDtoEntidadeDeveSerMapeadaParaUsuario()
        {
            //arrange
            //act
            var entidadeMapeada = Services.TransformarUpdadeDtoEmUsuario(UpdateDto);

            //assert
            Assert.IsType<UsuarioModel>(entidadeMapeada);
        }

        [Fact]
        public void DadoUsuarioEntidadeDeveSerMapeadaParaReadDto()
        {
            //arrange
            //act
            var entidadeMapeada = Services.TransformarUsuarioEmReadDto(Usuario);

            //assert
            Assert.IsType<ReadUsuarioDto>(entidadeMapeada);
        }
    }
}
