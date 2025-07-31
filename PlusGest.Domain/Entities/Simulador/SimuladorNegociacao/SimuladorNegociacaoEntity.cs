using PlusGest.Domain.Entities.Enums.Simulador;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlusGest.Domain.Entities.Simulador.SimuladorNegociacao
{
    public class SimuladorNegociacaoEntity
    {
        #region Propriedades
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid SimuladorNegociacaoId { get; set; }

        [Required]
        public Guid SimuladorId { get; set; }

        [Required]
        public EnumSimuladorNegociacaoTipo Tipo { get; set; }

        [Required]
        public EnumTipoCenarioNegociacao TipoCenario { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal PercentualDesconto { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal ValorDividaOriginal { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal ValorProposta { get; set; }

        public int PrazoQuitacaoDias { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal EconomiaGerada { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal ValorParcelaReduzida { get; set; }

        [Required]
        public int TotalParcelas { get; set; }
        #endregion
    }
}