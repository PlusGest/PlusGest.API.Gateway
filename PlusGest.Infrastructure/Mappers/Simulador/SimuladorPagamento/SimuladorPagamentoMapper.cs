using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlusGest.Domain.Entities.Simulador;
using PlusGest.Domain.Entities.Simulador.SimuladorPagamento;

namespace PlusGest.Infrastructure.Mappers.Simulador.SimuladorPagamento
{
    public static class SimuladorPagamentoMapper
    {
        public class SimuladorPagamento : IEntityTypeConfiguration<SimuladorPagamentoEntity>
        {
            public void Configure(EntityTypeBuilder<SimuladorPagamentoEntity> b)
            {
                //Primary Key
                b.HasKey(x => x.SimuladorPagamentoId);

                //Foreign Keys
                b.HasOne<SimuladorEntity>()
                    .WithOne()
                    .HasForeignKey<SimuladorPagamentoEntity>(x => x.SimuladorId)
                    .OnDelete(DeleteBehavior.Cascade);

                //Properties
                b.Property(x => x.FormaPagamento)
                    .IsRequired()
                    .HasConversion<int>();
                b.Property(x => x.Parcelas)
                    .IsRequired()
                    .HasDefaultValue(0);
                b.Property(x => x.ValorTotal)
                    .IsRequired()
                    .HasColumnType("decimal(10,2)");
                b.Property(x => x.ValorParcela)
                    .IsRequired()
                    .HasColumnType("decimal(10,2)");
                b.Property(x => x.TemJuros)
                    .IsRequired()
                    .HasDefaultValue(false);
                b.Property(x => x.PercentualJuros)
                    .HasColumnType("decimal(5,2)");
                b.Property(x => x.PercentualDesconto)
                    .HasColumnType("decimal(5,2)");
                b.Property(x => x.Observacao)
                    .HasMaxLength(500);

                //Table Mapping
                b.ToTable("SimuladorPagamento");
            }
        }
    }
}
