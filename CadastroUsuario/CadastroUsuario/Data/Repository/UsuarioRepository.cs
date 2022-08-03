using CadastroUsuario.Data.Dto;
using CadastroUsuario.Data.Repository.Contracts;
using CadastroUsuario.Services;
using CadastroUsuario.Services.Contracts;

namespace CadastroUsuario.Data.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DataContext Context;
        private readonly IUsuarioServices Services;
        public UsuarioRepository(DataContext context, UsuarioServices services)
        {
            Context = context;
            Services = services;
        }
        public ReadUsuarioDto CriarNovoUsuario(CreateUsuarioDto usuarioParaCriar)
        {
            var usuarioMapeado = Services.TransformarCreateDtoEmUsuario(usuarioParaCriar);
            if (usuarioMapeado != null)
            {
                usuarioMapeado.Id = Services.CriarId();
                usuarioMapeado.CreationDate = Services.BuscarHora();
                Context.Usuario.Add(usuarioMapeado);
                if (Context.SaveChanges() > 0)
                {
                    var usuarioRetorno = Services.TransformarUsuarioEmReadDto(usuarioMapeado);
                    if (usuarioRetorno != null) return usuarioRetorno;
                    throw new Exception("Erro no mapeamento");
                }
                throw new Exception("Erro ao salvar usuario no banco.");
            }
            throw new Exception("Erro no mapeamento");

        }

        public IEnumerable<ReadUsuarioDto> BuscarTodosOsUsuarios()
        {
            var usuarios = from usuario in Context.Usuario
                           select new ReadUsuarioDto()
                           {
                                Id=usuario.Id,
                                FirstName=usuario.FirstName,
                                SurName=usuario.SurName,
                                Age=usuario.Age,
                                CreationDate=usuario.CreationDate
                            };
            if (usuarios.Any()) return usuarios;
            return null;
        }

        public ReadUsuarioDto BuscarUsuarioPorId(string id)
        {
            var usuario = Context.Usuario.FirstOrDefault(u => u.Id == id);
            if (usuario != null)
            {
                var usuarioRetorno = Services.TransformarUsuarioEmReadDto(usuario);
                if (usuarioRetorno != null) return usuarioRetorno;
                    throw new Exception("Erro no mapeamento.");

            }
            throw new Exception("Erro na busca.");

        }


        public ReadUsuarioDto AtualizarUsuario(UpdateUsuarioDto usuarioParaAtualizar)
        {
            var usuarioMapeado = Services.TransformarUpdadeDtoEmUsuario(usuarioParaAtualizar);
            if (usuarioMapeado != null)
            {
                Context.Usuario.Update(usuarioMapeado);
                if (Context.SaveChanges() > 0)
                {
                    var usuarioParaRetornar = Services.TransformarUsuarioEmReadDto(usuarioMapeado);
                    if (usuarioParaRetornar != null) return usuarioParaRetornar;
                    throw new Exception("Erro no mapeamento.");

                }
                throw new Exception("Erro ao salvar atualização.");

            }
            throw new Exception("Erro no mapeamento.");

        }



        public bool DeletarUsuario(string id)
        {
            var usuarioParaDeletar = Context.Usuario.FirstOrDefault(u => u.Id == id);
            if (usuarioParaDeletar != null)
            {
                Context.Usuario.Remove(usuarioParaDeletar);
                if (Context.SaveChanges() > 0) return true;
                throw new Exception("Erro ao salvar deleção.");

            }
            return false;
        }
    }
}
