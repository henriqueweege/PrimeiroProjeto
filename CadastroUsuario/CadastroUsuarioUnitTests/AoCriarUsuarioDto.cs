using CadastroUsuario.Data.Dto;
using CadastroUsuario.Data.Dto.UsuarioDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuarioUnitTests
{
    public class AoCriarUsuarioDto
    {
        [Fact]
        public void DadoNumeroNoNomeTentativaDeCriarCreateUsuarioDtoDeveLancarExcecao()
        {
            //arrange
            var nome = "1";
            //act-assert
            var mensagem = Assert.Throws<FormatException>(
                    () => new CreateUsuarioDto() { FirstName = nome }
                );
            Assert.Equal("Nome não pode conter números.", mensagem.Message);
        }

        [Fact]
        public void DadoNumeroNoSobrenomeTentativaDeCriarCreateUsuarioDtoDeveLancarExcecao()
        {
            //arrange
            var nome = "nome";
            var sobrenome = "1";
            //act-assert
            var mensagem = Assert.Throws<FormatException>(
                    () => new CreateUsuarioDto() { FirstName = nome, SurName = sobrenome }
                );
            Assert.Equal("Sobrenome não pode conter números.", mensagem.Message);
        }

        [Fact]
        public void DadoNumeroNoNomeTentativaDeCriarReadUsuarioDtoDeveLancarExcecao()
        {
            //arrange
            var nome = "1";
            //act-assert
            var mensagem = Assert.Throws<FormatException>(
                    () => new ReadUsuarioDto() { FirstName = nome }
                );
            Assert.Equal("Nome não pode conter números.", mensagem.Message);
        }

        [Fact]
        public void DadoNumeroNoSobrenomeTentativaDeCriarReadUsuarioDtoDeveLancarExcecao()
        {
            //arrange
            var nome = "nome";
            var sobrenome = "1";
            //act-assert
            var mensagem = Assert.Throws<FormatException>(
                    () => new ReadUsuarioDto() { FirstName = nome, SurName = sobrenome }
                );
            Assert.Equal("Sobrenome não pode conter números.", mensagem.Message);
        }

        [Fact]
        public void DadoNumeroNoNomeTentativaDeCriarUpdateUsuarioDtoDeveLancarExcecao()
        {
            //arrange
            var nome = "1";
            //act-assert
            var mensagem = Assert.Throws<FormatException>(
                    () => new UpdateUsuarioDto() { FirstName = nome }
                );
            Assert.Equal("Nome não pode conter números.", mensagem.Message);
        }

        [Fact]
        public void DadoNumeroNoSobrenomeTentativaDeCriarUpdateUsuarioDtoDeveLancarExcecao()
        {
            //arrange
            var nome = "nome";
            var sobrenome = "1";
            //act-assert
            var mensagem = Assert.Throws<FormatException>(
                    () => new UpdateUsuarioDto() { FirstName = nome, SurName = sobrenome }
                );
            Assert.Equal("Sobrenome não pode conter números.", mensagem.Message);
        }


        [Fact]
        public void DadoParametrosCorretosTentativaDeCriarCreateUsuarioDtoDeveOcorrerComSucesso()
        {
            //arrange
            var firstName = "Nome";
            var surName = "Sobrenome";
            var age = 10;

            //act
            var usuario = new CreateUsuarioDto() { FirstName = firstName, SurName = surName, Age = age };

            //assert
            Assert.Equal(firstName, usuario.FirstName);
            Assert.Equal(surName, usuario.SurName);
            Assert.Equal(age, usuario.Age);

        }

        [Fact]
        public void DadoParametrosCorretosESurnameNullTentativaDeCriarCreateUsuarioDtoDeveOcorrerComSucesso()
        {
            //arrange
            var firstName = "Nome";
            var age = 10;

            //act
            var usuario = new CreateUsuarioDto() { FirstName = firstName, SurName = null, Age = age };

            //assert
            Assert.Equal(firstName, usuario.FirstName);
            Assert.Equal(null, usuario.SurName);
            Assert.Equal(age, usuario.Age);

        }

        [Fact]
        public void DadoParametrosCorretosTentativaDeCriarUpdateUsuarioDtoDeveOcorrerComSucesso()
        {
            //arrange
            var id = "id";
            var firstName = "Nome";
            var surName = "Sobrenome";
            var age = 10;
            var creationDate = DateTime.UtcNow;

            //act
            var usuario = new UpdateUsuarioDto() 
            { Id= id, 
              FirstName = firstName, 
              SurName = surName, 
              Age = age, 
              CreationDate = creationDate 
            };

            //assert
            Assert.Equal(firstName, usuario.FirstName);
            Assert.Equal(surName, usuario.SurName);
            Assert.Equal(age, usuario.Age);
            Assert.Equal(creationDate.ToString("d"), usuario.CreationDate.ToString("d"));


        }

        [Fact]
        public void DadoParametrosCorretosESurnameNullTentativaDeCriarUpdateUsuarioDtoDeveOcorrerComSucesso()
        {
            //arrange
            var id = "id";
            var firstName = "Nome";
            var age = 10;
            var creationDate = DateTime.UtcNow;

            //act
            var usuario = new UpdateUsuarioDto()
            {
                Id = id,
                FirstName = firstName,
                SurName = null,
                Age = age,
                CreationDate = creationDate
            };

            //assert
            Assert.Equal( firstName, usuario.FirstName);
            Assert.Equal( null, usuario.SurName);
            Assert.Equal( age, usuario.Age);
            Assert.Equal( creationDate.ToString("d"), usuario.CreationDate.ToString("d"));
        }

        [Fact]
        public void DadoParametrosCorretosTentativaDeCriarReadUsuarioDtoDeveOcorrerComSucesso()
        {
            //arrange
            var id = "id";
            var firstName = "Nome";
            var surName = "Sobrenome";
            var age = 10;
            var creationDate = DateTime.UtcNow;

            //act
            var usuario = new ReadUsuarioDto()
            {
                Id = id,
                FirstName = firstName,
                SurName = surName,
                Age = age,
                CreationDate = creationDate
            };

            //assert
            Assert.Equal(firstName, usuario.FirstName);
            Assert.Equal(surName, usuario.SurName);
            Assert.Equal(age, usuario.Age);
            Assert.Equal(creationDate.ToString("d"), usuario.CreationDate.ToString("d"));


        }

        [Fact]
        public void DadoParametrosCorretosESurnameNullTentativaDeCriarReadUsuarioDtoDeveOcorrerComSucesso()
        {
            //arrange
            var id = "id";
            var firstName = "Nome";
            var age = 10;
            var creationDate = DateTime.UtcNow;

            //act
            var usuario = new ReadUsuarioDto()
            {
                Id = id,
                FirstName = firstName,
                SurName = null,
                Age = age,
                CreationDate = creationDate
            };

            //assert
            Assert.Equal(firstName, usuario.FirstName);
            Assert.Equal(null, usuario.SurName);
            Assert.Equal(age, usuario.Age);
            Assert.Equal(creationDate.ToString("d"), usuario.CreationDate.ToString("d"));
        }


    }
}
