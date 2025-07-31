using PlusGest.Domain.Entities.Enums.Simulador;

namespace PlusGest.Domain.Presentation.Response.Simulador.SimuladorVeiculo
{
    public class SimuladorVeiculoResponse
    {
        #region Propriedades
        public Guid SimuladorVeiculoId { get; set; }
        public Guid SimuladorId { get; set; }
        public string? Veiculo { get; set; }
        public EnumBancoFinanceira BancoFinanceira { get; set; }
        public decimal ValorVeiculo { get; set; }
        public decimal ValorEntrada { get; set; }
        public decimal ValorParcela { get; set; }
        public decimal TotalParcelas { get; set; }
        public int VencimentoDia { get; set; }
        public int ParcelasPagas { get; set; }
        public int ParcelasAtraso { get; set; }
        public decimal ValorFinanciado { get; set; }
        public decimal TotalFinanciado { get; set; }
        public decimal JurosFinanciado { get; set; }
        public decimal TaxaJuros { get; set; }
        public int ParcelasRestantes { get; set; }
        public decimal ValorAberto { get; set; }
        public decimal ValorAtraso { get; set; }
        public decimal ValorFinalBem { get; set; } 
        #endregion
    }
}