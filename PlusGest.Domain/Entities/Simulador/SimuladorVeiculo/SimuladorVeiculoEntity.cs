using PlusGest.Domain.Entities.Enums.Simulador;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlusGest.Domain.Entities.Simulador.SimuladorVeiculo
{
    public class SimuladorVeiculoEntity
    {
        #region Propriedades do Banco de Dados
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid SimuladorVeiculoId { get; set; }

        [Required]
        public Guid SimuladorId { get; set; }

        [Required]
        [StringLength(60)]
        public string Veiculo { get; set; } = string.Empty;

        [Required]
        public EnumBancoFinanceira BancoFinanceira { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal ValorVeiculo { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal ValorEntrada { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal ValorParcela { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal TotalParcelas { get; set; }

        [Required]
        public int VencimentoDia { get; set; }

        [Required]
        public int ParcelasPagas { get; set; }

        [Required]
        public int ParcelasAtraso { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal ValorFinanciado { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal TotalFinanciado { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal JurosFinanciado { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal TaxaJuros { get; set; }

        [Required]
        public int ParcelasRestantes { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal ValorAberto { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal ValorAtraso { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal ValorFinalBem { get; set; }
        #endregion
    }
}