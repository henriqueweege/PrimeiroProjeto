using CadastroUsuario.Model;


namespace CadastroUsuarioUnitTests
{


    public class AoCriarUsuario
    { 

        [Fact]
        public void DadoInstaciaDeNovoUsuarioDevePossuirIdEDataDeCriacao()
        {
            //arrange
            //act
            var usuario = new UsuarioModel();

            //assert
            Assert.True(usuario.Id != null);
            Assert.True(usuario.CreationDate.ToString("d") == DateTime.Now.ToString("d"));

        }

        [Fact]
        public void DadoNumeroNoNomeTentativaDeCriarUsuarioDeveLancarExcecao()
        {
            //arrange
            var nome = "1";
            //act-assert
            var mensagem = Assert.Throws<FormatException>(
                    ()=>new UsuarioModel() { FirstName = nome}
                );
            Assert.Equal("Nome não pode conter números.", mensagem.Message);
        }

        [Fact]
        public void DadoNumeroNoSobrenomeTentativaDeCriarUsuarioDeveLancarExcecao()
        {
            //arrange
            var nome = "nome";
            var sobrenome = "1";
            //act-assert
            var mensagem = Assert.Throws<FormatException>(
                    () => new UsuarioModel() { FirstName = nome, SurName = sobrenome }
                );
            Assert.Equal("Sobrenome não pode conter números.", mensagem.Message);
        }

        

        [Fact]
        public void DadoParametrosCorretosTentativaDeCriarUsuarioDeveOcorrerComSucesso()
        {
            //arrange
            var firstName = "Nome";
            var surName = "Sobrenome";
            var age = 10;

            //act
            var usuario = new UsuarioModel() { FirstName = firstName, SurName = surName, Age = age };

            //assert
            Assert.True(usuario.Id != null);
            Assert.True(usuario.CreationDate.ToString("d") == DateTime.Now.ToString("d"));
            Assert.Equal(usuario.FirstName, firstName);
            Assert.Equal(usuario.SurName, surName);
            Assert.Equal(usuario.Age, age);

        }

        [Fact]
        public void DadoParametrosCorretosESurnameNullTentativaDeCriarUsuarioDeveOcorrerComSucesso()
        {
            //arrange
            var firstName = "Nome";
            var age = 10;

            //act
            var usuario = new UsuarioModel() { FirstName = firstName, SurName = null, Age = age };

            //assert
            Assert.True(usuario.Id != null);
            Assert.True(usuario.CreationDate.ToString("d") == DateTime.Now.ToString("d"));
            Assert.Equal(usuario.FirstName, firstName);
            Assert.Equal(usuario.SurName, null);
            Assert.Equal(usuario.Age, age);

        }
    }
}