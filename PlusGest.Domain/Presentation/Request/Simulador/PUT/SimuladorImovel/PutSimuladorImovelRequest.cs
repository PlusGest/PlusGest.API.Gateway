using PlusGest.Domain.Entities.Enums.Simulador;

namespace PlusGest.Domain.Presentation.Request.Simulador.PUT.SimuladorImovel
{
    public class PutSimuladorImovelRequest
    {
        #region Propriedades
        public Guid SimuladorImovelId { get; set; }
        public Guid SimuladorId { get; set; }
        public EnumBancoFinanceira BancoFinanceira { get; set; }
        public decimal ValorImovel { get; set; }
        public decimal ValorEntrada { get; set; }
        public decimal ValorFinanciado { get; set; }
        public decimal TaxaJurosAnual { get; set; }
        public decimal TaxaJurosMensal { get; set; }
        public int TotalParcelas { get; set; }
        public int VencimentoDia { get; set; }
        public decimal AmortizacaoMensal { get; set; }
        public decimal ValorParcelaInicial { get; set; }
        public decimal ValorParcelaFinal { get; set; }
        public decimal ValorTotalPago { get; set; }
        public decimal JurosTotal { get; set; } 
        #endregion
    }
}