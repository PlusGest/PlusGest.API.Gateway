using PlusGest.Domain.Entities.Enums.Usuario;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlusGest.Domain.Entities.Usuario
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
        public EnumStatusUsuario Status { get; set; }

        [Required]
        public EnumDepartamentoUsuario Departamento { get; set; }

        [Required]
        public EnumFuncaoUsuario Funcao { get; set; }

        [Required]
        public EnumUnidadeUsuario Unidade { get; set; }

        [Required]
        [StringLength(100)]
        public string NomeUsuario { get; set; } = string.Empty;

        [Required]
        [MaxLength(30)]
        [MinLength(3)]
        public string Senha { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string FotoUrl { get; set; } = string.Empty;

        [NotMapped]
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        #endregion
    }
}