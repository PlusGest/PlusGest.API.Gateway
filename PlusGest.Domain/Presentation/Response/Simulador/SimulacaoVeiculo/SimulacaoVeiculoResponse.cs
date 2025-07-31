using PlusGest.Domain.Presentation.Response.Simulador.SimuladorNegociacao;
using PlusGest.Domain.Presentation.Response.Simulador.SimuladorVeiculo;

namespace PlusGest.Domain.Presentation.Response.Simulador.SimulacaoVeiculo
{
    public class SimulacaoVeiculoResponse
    {
        #region Propriedades
        public SimuladorVeiculoResponse? Veiculo { get; set; }
        public ICollection<SimuladorNegociacaoResponse>? Negociacao { get; set; } 
        #endregion
    }
}