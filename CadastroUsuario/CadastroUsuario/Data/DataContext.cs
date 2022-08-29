using CadastroUsuario.Model;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;


namespace CadastroUsuario.Data
{
    public class DataContext : DbContext
    {
        public DbSet<UsuarioModel> Usuario { get; set; }
        public DbSet<LogModel> Log { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string stringconexao = "server = us-cdbr-east-06.cleardb.net; DataBase=heroku_5e6b90c0a0eec03;Uid=b9fa9681589f44;Pwd=f30c0fa8";
            optionsBuilder.UseMySql(stringconexao, ServerVersion.AutoDetect(stringconexao));
        }
    }
}
