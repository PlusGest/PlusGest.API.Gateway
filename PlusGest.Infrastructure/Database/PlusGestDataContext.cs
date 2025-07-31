using Microsoft.EntityFrameworkCore;
using PlusGest.Infrastructure.Mappers.Cliente;
using PlusGest.Infrastructure.Mappers.Cliente.ClienteObservacao;
using PlusGest.Infrastructure.Mappers.Simulador;
using PlusGest.Infrastructure.Mappers.Simulador.SimuladorCliente;
using PlusGest.Infrastructure.Mappers.Simulador.SimuladorImovel;
using PlusGest.Infrastructure.Mappers.Simulador.SimuladorNegociacao;
using PlusGest.Infrastructure.Mappers.Simulador.SimuladorPagamento;
using PlusGest.Infrastructure.Mappers.Simulador.SimuladorVeiculo;
using PlusGest.Infrastructure.Mappers.Usuario;

namespace PlusGest.Infrastructure.Database
{
    public class PlusGestDataContext : DbContext
    {
        public PlusGestDataContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 15));
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseMySql(
                    "Server=bklhjcbrq6iorwjcqlgk-mysql.services.clever-cloud.com; Port=3306; User=uso9unpcpqcjo1ee; Password=fYuvNFBJkT55YyOP6zEl; Database=bklhjcbrq6iorwjcqlgk;",
                    serverVersion);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Usuario
            modelBuilder.ApplyConfiguration(new UsuarioMapper.Usuario());
            
            //Simulador
            modelBuilder.ApplyConfiguration(new SimuladorMapper.Simulador());
            modelBuilder.ApplyConfiguration(new SimuladorClienteMapper.SimuladorCliente());
            modelBuilder.ApplyConfiguration(new SimuladorImovelMapper.SimuladorImovel());
            modelBuilder.ApplyConfiguration(new SimuladorNegociacaoMapper.SimuladorNegociacao());
            modelBuilder.ApplyConfiguration(new SimuladorPagamentoMapper.SimuladorPagamento());
            modelBuilder.ApplyConfiguration(new SimuladorVeiculoMapper.SimuladorVeiculo());

            //Cliente
            modelBuilder.ApplyConfiguration(new ClienteMapper.Cliente());
            modelBuilder.ApplyConfiguration(new ClienteObservacaoMapper.ClienteObservacao());
        }
    }
}
