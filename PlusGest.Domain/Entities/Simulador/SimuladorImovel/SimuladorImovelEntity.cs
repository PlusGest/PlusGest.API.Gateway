using PlusGest.Domain.Entities.Enums.Simulador;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlusGest.Domain.Entities.Simulador.SimuladorImovel
{
    public class SimuladorImovelEntity
    {
        #region Propriedades
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid SimuladorImovelId { get; set; }

        [Required]
        public Guid SimuladorId { get; set; }

        [Required]
        public EnumBancoFinanceira BancoFinanceira { get; set; }

        [Required]
        [Column(TypeName = "decimal(12,2)")]
        public decimal ValorImovel { get; set; }

        [Required]
        [Column(TypeName = "decimal(12,2)")]
        public decimal ValorEntrada { get; set; }

        [Required]
        [Column(TypeName = "decimal(12,2)")]
        public decimal ValorFinanciado { get; set; }

        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal TaxaJurosAnual { get; set; }

        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal TaxaJurosMensal { get; set; }

        [Required]
        public int TotalParcelas { get; set; }

        [Required]
        public int VencimentoDia { get; set; }

        [Required]
        [Column(TypeName = "decimal(12,2)")]
        public decimal AmortizacaoMensal { get; set; }

        [Required]
        [Column(TypeName = "decimal(12,2)")]
        public decimal ValorParcelaInicial { get; set; }

        [Required]
        [Column(TypeName = "decimal(12,2)")]
        public decimal ValorParcelaFinal { get; set; }

        [Required]
        [Column(TypeName = "decimal(12,2)")]
        public decimal ValorTotalPago { get; set; }

        [Required]
        [Column(TypeName = "decimal(12,2)")]
        public decimal JurosTotal { get; set; }
        #endregion
    }
}