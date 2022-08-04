using CadastroUsuario.Model;

namespace CadastroUsuarioUnitTests
{
    public class AoCriarUsuario
    {
        [Fact]
        public void DadoInstaciaDeNovoUsuarioDevePossuorId()
        {
            //arrange
            //act
            var usuario = new Usuario();

            //assert
            Assert.True(usuario.Id != null);
        }
    }
}