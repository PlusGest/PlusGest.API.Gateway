using PlusGest.Domain.Entities.Enums.Simulador;
using PlusGest.Domain.Presentation.Request.Simulador.POST.SimuladorCliente;
using PlusGest.Domain.Presentation.Request.Simulador.POST.SimuladorImovel;
using PlusGest.Domain.Presentation.Request.Simulador.POST.SimuladorNegociacao;
using PlusGest.Domain.Presentation.Request.Simulador.POST.SimuladorPagamento;
using PlusGest.Domain.Presentation.Request.Simulador.POST.SimuladorVeiculo;

namespace PlusGest.Domain.Presentation.Request.Simulador.POST
{
    public class PostSimuladorCompletoRequest
    {
        #region Propriedades
        public EnumSimuladorTipo Tipo { get; set; }
        public EnumSimuladorStatus Status { get; set; }
        public DateTime DataAtentimento { get; set; }
        public DateTime DataExpriracao { get; set; }
        public bool DadosAnonimizados { get; set; } = false;
        public EnumSimuladorMidia Midia { get; set; }
        public PostSimuladorClienteRequest Cliente { get; set; } = new PostSimuladorClienteRequest();
        public PostSimuladorVeiculoRequest Veiculo { get; set; } = new PostSimuladorVeiculoRequest();
        public PostSimuladorImovelRequest Imovel { get; set; } = new PostSimuladorImovelRequest();
        public ICollection<PostSimuladorNegociacaoRequest> Negociacao { get; set; } = new List<PostSimuladorNegociacaoRequest>();
        public PostSimuladorPagamentoRequest Pagamento { get; set; } = new PostSimuladorPagamentoRequest(); 
        #endregion
    }
}