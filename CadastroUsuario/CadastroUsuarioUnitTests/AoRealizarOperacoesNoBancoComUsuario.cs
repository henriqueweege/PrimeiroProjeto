using AutoMapper;
using CadastroUsuario.Data;
using CadastroUsuario.Data.Dto.UsuarioDto;
using CadastroUsuario.Data.Repository;
using CadastroUsuario.Data.Repository.Contracts;
using CadastroUsuario.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuarioUnitTests
{
    public class AoRealizarOperacoesNoBancoComUsuario :IClassFixture<CadastraUsuarioFixture>
    {
        private IUsuarioRepository UsuarioRepository { get; set; }
        public CreateUsuarioDto CreateUsuarioDto { get; set; }
        public UpdateUsuarioDto UpdateUsuarioDto { get; set; }

        public AoRealizarOperacoesNoBancoComUsuario(CadastraUsuarioFixture fixture)
        {
            UsuarioRepository = fixture.Repository;  
            CreateUsuarioDto = fixture.CreateUsuarioDto;
            UpdateUsuarioDto = fixture.UpdateUsuarioDto;
        }

        [Fact]
        public void DadoDtoCriadoRepositoryDeveRetornarReadDtoValido()
        {
            //arrange
            //act
            var dtoResposta = UsuarioRepository.CriarNovoUsuario(CreateUsuarioDto);

            //assert
            Assert.Equal("primeiroNome", dtoResposta.FirstName);
            Assert.True(dtoResposta.CreationDate.ToString().DefaultIfEmpty() != null);
            Assert.True(dtoResposta.Id.ToString().DefaultIfEmpty() != null);

        }

        [Fact]
        public void DadoBancoDeDadosPopuladoRepositoryDeveRetornarUmOuMaisObjetos()
        {
            //arrange
            UsuarioRepository.CriarNovoUsuario(CreateUsuarioDto);
            //act
            var resposta = UsuarioRepository.BuscarTodosOsUsuarios();

            //assert
            Assert.True(resposta.ToList().Count > 0);
        }

        [Fact]
        public void DadoUsuarioCriadoRepositoryDeveRetornarObjetoCriado()
        {
            //arrange
            var usuarioCriado = UsuarioRepository.CriarNovoUsuario(CreateUsuarioDto);

            //act
            var resposta = UsuarioRepository.BuscarUsuarioPorId(usuarioCriado.Id);

            //assert
            Assert.Equal(usuarioCriado.Id, resposta.Id);
        }

        [Fact]
        public void DadoObjetoModificadoRepositoryDeveRetonarObjetoAtualizado()
        {
            //arrange
            var nome = CreateUsuarioDto.FirstName;
            var usuarioCriado = UsuarioRepository.CriarNovoUsuario(CreateUsuarioDto);
            UpdateUsuarioDto.Id = usuarioCriado.Id;

            //act
            var resposta = UsuarioRepository.AtualizarUsuario(UpdateUsuarioDto);

            //assert
            Assert.False(resposta.FirstName == nome);
        }

        [Fact]
        public void DadoObjetoCriadoRepositoryDeveExcluirComSucesso()
        {
            //arrange
            var usuarioCriado = UsuarioRepository.CriarNovoUsuario(CreateUsuarioDto);

            //act
            var resposta = UsuarioRepository.DeletarUsuario(usuarioCriado.Id);

            //assert
            Assert.True(resposta);
        }


        [Fact]
        public void DadoIdInvalidoRepositoryDeveRetornarFalseQuandoSolicitadoExclusao()
        {
            //arrange
            var id = "não é um Id válido";

            //act
            var resposta = UsuarioRepository.DeletarUsuario(id);

            //assert
            Assert.False(resposta);
        }

        [Fact]
        public void DadoIdInvalidoRepositoryDeveRetornarExcecaoQuandoSolicitadoBuscaDeUsuario()
        {

            //arrange
            var id = "não é um Id válido";


            //act-assert
            var mensagem = Assert.Throws<Exception>(

                    () => UsuarioRepository.BuscarUsuarioPorId(id)
                );

            Assert.Equal("Id inválido.", mensagem.Message);
        }
    }
}
