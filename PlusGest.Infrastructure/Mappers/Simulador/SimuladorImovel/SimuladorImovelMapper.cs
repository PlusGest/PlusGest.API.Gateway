using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlusGest.Domain.Entities.Simulador;
using PlusGest.Domain.Entities.Simulador.SimuladorImovel;

namespace PlusGest.Infrastructure.Mappers.Simulador.SimuladorImovel
{
    public static class SimuladorImovelMapper
    {
        public class SimuladorImovel : IEntityTypeConfiguration<SimuladorImovelEntity>
        {
            public void Configure(EntityTypeBuilder<SimuladorImovelEntity> b)
            {
                //Primary Key
                b.HasKey(x => x.SimuladorImovelId);

                //Foreign Keys
                b.HasOne<SimuladorEntity>()
                    .WithOne()
                    .HasForeignKey<SimuladorImovelEntity>(x => x.SimuladorId)
                    .OnDelete(DeleteBehavior.Cascade);

                //Properties
                b.Property(x => x.BancoFinanceira)
                    .IsRequired()
                    .HasConversion<int>();
                b.Property(x => x.ValorImovel)
                    .IsRequired()
                    .HasColumnType("decimal(12,2)");
                b.Property(x => x.ValorEntrada)
                    .IsRequired()
                    .HasColumnType("decimal(12,2)");
                b.Property(x => x.ValorFinanciado)
                    .IsRequired()
                    .HasColumnType("decimal(12,2)");
                b.Property(x => x.TaxaJurosAnual)
                    .IsRequired()
                    .HasColumnType("decimal(5,2)");
                b.Property(x => x.TaxaJurosMensal)
                    .IsRequired()
                    .HasColumnType("decimal(5,2)");
                b.Property(x => x.TotalParcelas)
                    .IsRequired()
                    .HasDefaultValue(0);
                b.Property(x => x.VencimentoDia)
                    .IsRequired()
                    .HasDefaultValue(0);
                b.Property(x => x.AmortizacaoMensal)
                    .IsRequired()
                    .HasColumnType("decimal(12,2)");
                b.Property(x => x.ValorParcelaInicial)
                    .IsRequired()
                    .HasColumnType("decimal(12,2)");
                b.Property(x => x.ValorParcelaFinal)
                    .IsRequired()
                    .HasColumnType("decimal(12,2)");
                b.Property(x => x.ValorTotalPago)
                    .IsRequired()
                    .HasColumnType("decimal(12,2)");
                b.Property(x => x.JurosTotal)
                    .IsRequired()
                    .HasColumnType("decimal(12,2)");

                //Table Mapping
                b.ToTable("SimuladorImovel");
            }
        }
    }
}
