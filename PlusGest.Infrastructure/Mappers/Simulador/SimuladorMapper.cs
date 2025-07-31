using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlusGest.Domain.Entities.Simulador;
using PlusGest.Domain.Entities.Usuario;

namespace PlusGest.Infrastructure.Mappers.Simulador
{
    public static class SimuladorMapper
    {
        public class Simulador : IEntityTypeConfiguration<SimuladorEntity>
        {
            public void Configure(EntityTypeBuilder<SimuladorEntity> b)
            {
                //Primary Key
                b.HasKey(x => x.SimuladorId);

                //Foreign Keys
                b.HasOne<UsuarioEntity>()
                    .WithMany()
                    .HasForeignKey(x => x.UsuarioId)
                    .OnDelete(DeleteBehavior.Restrict);

                //Properties
                b.Property(x => x.Tipo)
                    .IsRequired()
                    .HasConversion<int>();
                b.Property(x => x.Status)
                    .IsRequired()
                    .HasConversion<int>();
                b.Property(x => x.DataAtentimento)
                    .IsRequired()
                    .HasColumnType("datetime");
                b.Property(x => x.DataExpriracao)
                    .IsRequired()
                    .HasColumnType("datetime");
                b.Property(x => x.DadosAnonimizados)
                    .IsRequired()
                    .HasDefaultValue(false);
                b.Property(x => x.Midia)
                    .IsRequired()
                    .HasConversion<int>();
                b.Property(x => x.DataCriacao)
                    .IsRequired()
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                //Table Mapping
                b.ToTable("Simulador");
            }
        }
    }
}
