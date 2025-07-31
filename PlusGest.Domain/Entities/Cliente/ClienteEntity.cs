using PlusGest.Domain.Entities.Enums.Cliente;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlusGest.Domain.Entities.Cliente
{
    public class ClienteEntity
    {
        #region Propriedades
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ClienteId { get; set; }

        [Required]
        public Guid Usuarioid { get; set; }

        [Required]
        public Guid SimuladorId { get; set; }

        [Required]
        [StringLength(200)]
        public string NomeCompleto { get; set; } = string.Empty;

        [Required]
        [StringLength(12)]
        public string Rg { get; set; } = string.Empty;

        [Required]
        [StringLength(14)]
        public string Cpf { get; set; } = string.Empty;

        [Required]
        public EnumClienteStatus Status { get; set; }

        [Required]
        public DateTime DataNascimento { get; set; }

        [Required]
        [StringLength(15)]
        public string Telefone { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(9)]
        public string Cep { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Endereço { get; set; } = string.Empty;

        [Required]
        public int Numero { get; set; }

        [Required]
        [StringLength(100)]
        public string Cidade { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Estado { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string FotoUrl { get; set; } = string.Empty;

        [NotMapped]
        public DateTime DataCadastro { get; set; }
        #endregion
    }
}