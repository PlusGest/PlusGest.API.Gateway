using Microsoft.EntityFrameworkCore;
using PlusGest.Gateway.Infrastructure.Mappers.Cliente;
using PlusGest.Infrastructure.Mappers.Cliente.ClienteObservacao;
using PlusGest.Infrastructure.Mappers.Usuario;

namespace PlusGest.Gateway.Infrastructure.Database
{
    public class PlusGestDataContext : DbContext
    {
        #region Construtor
        public PlusGestDataContext() { }
        #endregion

        #region Configuração da String de Conexão do Banco de Dados
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 15));
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseMySql(
                    "Server=bklhjcbrq6iorwjcqlgk-mysql.services.clever-cloud.com; Port=3306; User=uso9unpcpqcjo1ee; Password=fYuvNFBJkT55YyOP6zEl; Database=bklhjcbrq6iorwjcqlgk;",
                    serverVersion);

            base.OnConfiguring(optionsBuilder);
        }
        #endregion

        #region Adicionando os Mappers Para Banco de Dados
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Usuario
            modelBuilder.ApplyConfiguration(new UsuarioMapper.Usuario());

            //Cliente
            modelBuilder.ApplyConfiguration(new ClienteMapper.Cliente());
            modelBuilder.ApplyConfiguration(new ClienteObservacaoMapper.ClienteObservacao());
        } 
        #endregion
    }
}