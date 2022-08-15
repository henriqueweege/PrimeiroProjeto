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
            string stringconexao = "server = localhost; DataBase=UsuarioDb;Uid=root;Pwd=root";
            optionsBuilder.UseMySql(stringconexao, ServerVersion.AutoDetect(stringconexao));
        }
    }
}
