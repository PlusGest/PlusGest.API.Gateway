using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlusGest.Gateway.Domain.Entities.Cliente;
using PlusGest.Gateway.Domain.Entities.Cliente.ClienteObservacao;

namespace PlusGest.Infrastructure.Mappers.Cliente.ClienteObservacao
{
    public static class ClienteObservacaoMapper
    {
        public class ClienteObservacao : IEntityTypeConfiguration<ClienteObservacaoEntity>
        {
            public void Configure(EntityTypeBuilder<ClienteObservacaoEntity> b)
            {
                //Primary Key
                b.HasKey(x => x.ClienteObservacaoId);

                //Foreign Keys
                b.HasOne<ClienteEntity>()
                    .WithOne()
                    .HasForeignKey<ClienteObservacaoEntity>(x => x.ClienteId)
                    .OnDelete(DeleteBehavior.Cascade);

                //Properties
                b.Property(x => x.Obervacao)
                    .IsRequired()
                    .HasMaxLength(500);
                b.Property(x => x.DataCadastro)
                    .IsRequired()
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                //Table Mapping
                b.ToTable("ClienteObservacao");
            }
        }
    }
}
