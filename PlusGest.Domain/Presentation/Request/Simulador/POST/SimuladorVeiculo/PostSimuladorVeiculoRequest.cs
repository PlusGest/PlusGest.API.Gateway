using PlusGest.Domain.Entities.Enums.Simulador;

namespace PlusGest.Domain.Presentation.Request.Simulador.POST.SimuladorVeiculo
{
    public class PostSimuladorVeiculoRequest
    {
        #region Propriedades
        public string Veiculo { get; set; } = string.Empty;
        public EnumBancoFinanceira BancoFinanceira { get; set; }
        public decimal ValorVeiculo { get; set; }
        public decimal ValorEntrada { get; set; }
        public decimal ValorParcela { get; set; }
        public int TotalParcelas { get; set; }
        public int VencimentoDia { get; set; }
        public int ParcelasPagas { get; set; }
        public int ParcelasAtraso { get; set; } 
        #endregion
    }
}