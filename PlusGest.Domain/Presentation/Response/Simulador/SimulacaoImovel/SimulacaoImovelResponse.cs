using PlusGest.Domain.Presentation.Response.Simulador.SimuladorImovel;
using PlusGest.Domain.Presentation.Response.Simulador.SimuladorNegociacao;

namespace PlusGest.Domain.Presentation.Response.Simulador.SimulacaoImovel
{
    public class SimulacaoImovelResponse
    {
        #region Propriedades
        public SimuladorImovelResponse? Imovel { get; set; }
        public ICollection<SimuladorNegociacaoResponse>? Negociacao { get; set; } 
        #endregion
    }
}