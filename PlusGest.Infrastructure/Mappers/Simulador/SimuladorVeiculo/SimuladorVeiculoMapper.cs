using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlusGest.Domain.Entities.Simulador;
using PlusGest.Domain.Entities.Simulador.SimuladorVeiculo;

namespace PlusGest.Infrastructure.Mappers.Simulador.SimuladorVeiculo
{
    public static class SimuladorVeiculoMapper
    {
        public class SimuladorVeiculo : IEntityTypeConfiguration<SimuladorVeiculoEntity>
        {
            public void Configure(EntityTypeBuilder<SimuladorVeiculoEntity> b)
            {
                //Primary Key
                b.HasKey(x => x.SimuladorVeiculoId);

                //Foreign Keys
                b.HasOne<SimuladorEntity>()
                    .WithOne()
                    .HasForeignKey<SimuladorVeiculoEntity>(x => x.SimuladorId)
                    .OnDelete(DeleteBehavior.Cascade);

                //Properties
                b.Property(x => x.Veiculo)
                    .IsRequired()
                    .HasMaxLength(60);
                b.Property(x => x.BancoFinanceira)
                    .IsRequired()
                    .HasConversion<int>();
                b.Property(x => x.ValorVeiculo)
                    .IsRequired()
                    .HasColumnType("decimal(10,2)");
                b.Property(x => x.ValorEntrada)
                    .IsRequired()
                    .HasColumnType("decimal(10,2)");
                b.Property(x => x.ValorParcela)
                    .IsRequired()
                    .HasColumnType("decimal(10,2)");
                b.Property(x => x.TotalParcelas)
                    .IsRequired()
                    .HasColumnType("decimal(10,2)");
                b.Property(x => x.VencimentoDia)
                    .IsRequired()
                    .HasDefaultValue(0);
                b.Property(x => x.ParcelasPagas)
                    .IsRequired()
                    .HasDefaultValue(0);
                b.Property(x => x.ParcelasAtraso)
                    .IsRequired()
                    .HasDefaultValue(0);
                b.Property(x => x.ValorFinanciado)
                    .IsRequired()
                    .HasColumnType("decimal(10,2)");
                b.Property(x => x.TotalFinanciado)
                    .IsRequired()
                    .HasColumnType("decimal(10,2)");
                b.Property(x => x.JurosFinanciado)
                    .IsRequired();
                b.Property(x => x.TaxaJuros)
                    .IsRequired()
                    .HasColumnType("decimal(10,2)");
                b.Property(x => x.ParcelasRestantes)
                    .IsRequired()
                    .HasDefaultValue(0);
                b.Property(x => x.ValorAberto)
                    .IsRequired()
                    .HasColumnType("decimal(10,2)");
                b.Property(x => x.ValorAtraso)
                    .IsRequired()
                    .HasColumnType("decimal(10,2)");
                b.Property(x => x.ValorFinalBem)
                    .IsRequired()
                    .HasColumnType("decimal(10,2)");

                //Table Mapping
                b.ToTable("SimuladorVeiculo");
            }
        }
    }
}
