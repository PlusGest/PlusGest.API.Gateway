using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlusGest.Domain.Entities.Simulador;
using PlusGest.Domain.Entities.Simulador.SimuladorCliente;

namespace PlusGest.Infrastructure.Mappers.Simulador.SimuladorCliente
{
    public static class SimuladorClienteMapper
    {
        public class SimuladorCliente : IEntityTypeConfiguration<SimuladorClienteEntity>
        {
            public void Configure(EntityTypeBuilder<SimuladorClienteEntity> b)
            {
                //Primary Key
                b.HasKey(x => x.SimuladorClienteId);

                //Foreign Keys
                b.HasOne<SimuladorEntity>()
                    .WithOne()
                    .HasForeignKey<SimuladorClienteEntity>(x => x.SimuladorId)
                    .OnDelete(DeleteBehavior.Cascade);

                //Properties
                b.Property(x => x.NomeCompleto)
                    .IsRequired()
                    .HasMaxLength(200);
                b.Property(x => x.Telefone)
                    .IsRequired()
                    .HasMaxLength(14);

                //Table Mapping
                b.ToTable("SimuladorCliente");
            }
        }
    }
}