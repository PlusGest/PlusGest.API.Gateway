using PlusGest.Gateway.Domain.Entities.Enums.Usuario;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace PlusGest.Gateway.Domain.Entities.Usuario
{
    public class UsuarioEntity
    {
        #region Propriedades
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UsuarioId { get; set; }

        [Required]
        [StringLength(200)]
        public string NomeCompleto { get; set; } = string.Empty;

        [Required]
        [StringLength(14)]
        public string CPF { get; set; } = string.Empty;

        [Required]
        public DateTime DataNascimento { get; set; }

        [Required]
        [StringLength(200)]
        public string EmailCorporativo { get; set; } = string.Empty;

        [Required]
        public EnumStatusUsuario Status { get; set; }

        [Required]
        public EnumDepartamentoUsuario Departamento { get; set; }

        [Required]
        public EnumFuncaoUsuario Funcao { get; set; }

        [Required]
        public EnumUnidadeUsuario Unidade { get; set; }

        [Required]
        [StringLength(100)]
        public string Login { get; set; } = string.Empty;

        [Required]
        [MaxLength(30)]
        [MinLength(3)]
        public string Senha { get; set; } = string.Empty;

        [NotNull]
        [StringLength(200)]
        public string? FotoUrl { get; set; } 

        [NotMapped]
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        #endregion
    }
}