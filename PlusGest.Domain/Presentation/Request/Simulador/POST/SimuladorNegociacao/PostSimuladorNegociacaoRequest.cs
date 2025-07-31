using PlusGest.Domain.Entities.Enums.Simulador;

namespace PlusGest.Domain.Presentation.Request.Simulador.POST.SimuladorNegociacao
{
    public class PostSimuladorNegociacaoRequest
    {
        #region Propriedades
        public EnumSimuladorNegociacaoTipo Tipo { get; set; }
        public EnumTipoCenarioNegociacao TipoCenario { get; set; }
        public decimal PercentualDesconto { get; set; }
        public decimal ValorDividaOriginal { get; set; }
        public decimal ValorProposta { get; set; }
        public int PrazoQuitacaoDias { get; set; }
        public decimal EconomiaGerada { get; set; }
        public decimal ValorParcelaReduzida { get; set; }
        public int TotalParcelas { get; set; } 
        #endregion
    }
}