using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlusGest.Domain.Entities.Simulador;
using PlusGest.Domain.Entities.Simulador.SimuladorNegociacao;

namespace PlusGest.Infrastructure.Mappers.Simulador.SimuladorNegociacao
{
    public static class SimuladorNegociacaoMapper
    {
        public class SimuladorNegociacao : IEntityTypeConfiguration<SimuladorNegociacaoEntity>
        {
            public void Configure(EntityTypeBuilder<SimuladorNegociacaoEntity> b)
            {
                //Primary Key
                b.HasKey(x => x.SimuladorNegociacaoId);

                //Foreign Keys
                b.HasOne<SimuladorEntity>()
                    .WithMany()
                    .HasForeignKey(x => x.SimuladorId)
                    .OnDelete(DeleteBehavior.Cascade);

                //Properties
                b.Property(x => x.Tipo)
                    .IsRequired()
                    .HasConversion<int>();
                b.Property(x => x.TipoCenario)
                    .IsRequired()
                    .HasConversion<int>();
                b.Property(x => x.PercentualDesconto)
                    .IsRequired()
                    .HasColumnType("decimal(5,2)");
                b.Property(x => x.ValorDividaOriginal)
                    .IsRequired()
                    .HasColumnType("decimal(10,2)");
                b.Property(x => x.ValorProposta)
                    .IsRequired()
                    .HasColumnType("decimal(10,2)");
                b.Property(x => x.PrazoQuitacaoDias)
                    .IsRequired()
                    .HasDefaultValue(0);
                b.Property(x => x.EconomiaGerada)
                    .IsRequired()
                    .HasColumnType("decimal(10,2)");
                b.Property(x => x.ValorParcelaReduzida)
                    .HasColumnType("decimal(10,2)");
                b.Property(x => x.TotalParcelas)
                    .IsRequired()
                    .HasDefaultValue(0);

                //Table Mapping
                b.ToTable("SimuladorNegociacao");
            }
        }
    }
}
