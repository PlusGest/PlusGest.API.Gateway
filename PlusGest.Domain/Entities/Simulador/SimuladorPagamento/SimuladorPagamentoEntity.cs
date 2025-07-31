using PlusGest.Domain.Entities.Enums.Simulador;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlusGest.Domain.Entities.Simulador.SimuladorPagamento
{
    public class SimuladorPagamentoEntity
    {
        #region Propriedades
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid SimuladorPagamentoId { get; set; }

        [Required]
        public Guid SimuladorId { get; set; }

        [Required]
        public EnumSimuladorFormaPagemento FormaPagamento { get; set; }

        [Required]
        public int Parcelas { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal ValorTotal { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal ValorParcela { get; set; }

        [Required]
        public bool TemJuros { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal PercentualJuros { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal PercentualDesconto { get; set; }

        [StringLength(500)]
        public string? Observacao { get; set; }
        #endregion
    }
}