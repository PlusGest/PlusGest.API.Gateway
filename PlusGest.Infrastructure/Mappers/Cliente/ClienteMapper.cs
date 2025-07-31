using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlusGest.Domain.Entities.Cliente;
using PlusGest.Domain.Entities.Simulador;
using PlusGest.Domain.Entities.Usuario;

namespace PlusGest.Infrastructure.Mappers.Cliente
{
    public static class ClienteMapper
    {
        public class Cliente : IEntityTypeConfiguration<ClienteEntity>
        {
            public void Configure(EntityTypeBuilder<ClienteEntity> b)
            {
                //Primary Key
                b.HasKey(x => x.ClienteId);

                //Foreign Keys
                b.HasOne<UsuarioEntity>()
                   .WithMany()
                   .HasForeignKey(x => x.Usuarioid)
                   .OnDelete(DeleteBehavior.Restrict);
                b.HasOne<SimuladorEntity>()
                     .WithMany()
                     .HasForeignKey(x => x.SimuladorId)
                     .OnDelete(DeleteBehavior.Restrict);

                //Properties
                b.Property(x => x.NomeCompleto)
                    .IsRequired()
                    .HasMaxLength(200);
                b.Property(x => x.Rg)
                    .IsRequired()
                    .HasMaxLength(12);
                b.Property(x => x.Cpf)
                    .IsRequired()
                    .HasMaxLength(14);
                b.Property(x => x.Status)
                    .IsRequired()
                    .HasConversion<int>();
                b.Property(x => x.DataNascimento)
                    .IsRequired()
                    .HasColumnType("datetime");
                b.Property(x => x.Telefone)
                    .IsRequired()
                    .HasMaxLength(15);
                b.Property(x => x.Email)
                    .IsRequired()
                    .HasMaxLength(200);
                b.Property(x => x.Cep)
                    .IsRequired()
                    .HasMaxLength(9);
                b.Property(x => x.Endereço)
                    .IsRequired()
                    .HasMaxLength(100);
                b.Property(x => x.Numero)
                    .IsRequired()
                    .HasDefaultValue(0);
                b.Property(x => x.Cidade)
                    .IsRequired()
                    .HasMaxLength(100);
                b.Property(x => x.Estado)
                    .IsRequired()
                    .HasMaxLength(100);

                //Table Mapping
                b.ToTable("Cliente");
            }
        }
    }
}
