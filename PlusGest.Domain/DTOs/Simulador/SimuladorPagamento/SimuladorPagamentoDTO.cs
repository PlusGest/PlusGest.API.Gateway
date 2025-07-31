using PlusGest.Domain.Entities.Enums.Simulador;

namespace PlusGest.Domain.DTOs.Simulador.SimuladorPagamento
{
    public class SimuladorPagamentoDTO
    {
        #region Propriedades
        public Guid SimuladorPagamentoId { get; set; }
        public Guid SimuladorId { get; set; }
        public EnumSimuladorFormaPagemento FormaPagamento { get; set; }
        public int Parcelas { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal ValorParcela { get; set; }
        public bool TemJuros { get; set; }
        public decimal PercentualJuros { get; set; }
        public decimal PercentualDesconto { get; set; }
        public string? Observacao { get; set; } 
        #endregion
    }
}