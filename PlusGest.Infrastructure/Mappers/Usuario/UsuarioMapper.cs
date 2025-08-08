using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlusGest.Gateway.Domain.Entities.Usuario;

namespace PlusGest.Infrastructure.Mappers.Usuario
{
    public static class UsuarioMapper
    {
        public class Usuario : IEntityTypeConfiguration<UsuarioEntity> 
        {
            #region Mapper
            public void Configure(EntityTypeBuilder<UsuarioEntity> b)
            {
                //Primary Key
                b.HasKey(x => x.UsuarioId);

                //Properties
                b.Property(x => x.NomeCompleto)
                    .IsRequired()
                    .HasMaxLength(200);
                b.Property(x => x.CPF)
                    .IsRequired()
                    .HasMaxLength(14);
                b.Property(x => x.DataNascimento)
                    .IsRequired()
                    .HasColumnType("datetime");
                b.Property(x => x.EmailCorporativo)
                    .IsRequired()
                    .HasMaxLength(200);
                b.Property(x => x.Status)
                    .IsRequired()
                    .HasConversion<int>();
                b.Property(x => x.Departamento)
                    .IsRequired()
                    .HasConversion<int>();
                b.Property(x => x.Funcao)
                    .IsRequired()
                    .HasConversion<int>();
                b.Property(x => x.Unidade)
                    .IsRequired()
                    .HasConversion<int>();
                b.Property(x => x.Login)
                    .IsRequired()
                    .HasMaxLength(200);
                b.Property(x => x.Senha)
                    .IsRequired()
                    .HasMaxLength(30);
                b.Property(x => x.FotoUrl)
                    .HasMaxLength(200);
                b.Property(x => x.DataCadastro)
                    .IsRequired()
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                //Table Mapping
                b.ToTable("Usuario");
            } 
            #endregion
        }
    }
}