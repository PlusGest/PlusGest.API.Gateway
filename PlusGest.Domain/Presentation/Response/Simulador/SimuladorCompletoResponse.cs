using PlusGest.Domain.Entities.Enums.Simulador;
using PlusGest.Domain.Presentation.Response.Simulador.SimuladorCliente;
using PlusGest.Domain.Presentation.Response.Simulador.SimuladorImovel;
using PlusGest.Domain.Presentation.Response.Simulador.SimuladorNegociacao;
using PlusGest.Domain.Presentation.Response.Simulador.SimuladorPagamento;
using PlusGest.Domain.Presentation.Response.Simulador.SimuladorVeiculo;

namespace PlusGest.Domain.Presentation.Response.Simulador
{
    public class SimuladorCompletoResponse
    {
        public Guid SimuladorId { get; set; }
        public Guid UsuarioId { get; set; }
        public EnumSimuladorTipo Tipo { get; set; }
        public EnumSimuladorStatus Status { get; set; }
        public DateTime DataAtentimento { get; set; }
        public DateTime DataExpriracao { get; set; }
        public bool DadosAnonimizados { get; set; }
        public EnumSimuladorMidia Midia { get; set; }
        public DateTime DataCriacao { get; set; }
        public SimuladorClienteResponse Cliente { get; set; } = new SimuladorClienteResponse();
        public SimuladorImovelResponse Imovel { get; set; } = new SimuladorImovelResponse();
        public SimuladorVeiculoResponse Veiculo { get; set; } = new SimuladorVeiculoResponse();
        public ICollection<SimuladorNegociacaoResponse> Negociacao { get; set; } = new List<SimuladorNegociacaoResponse>();
        public SimuladorPagamentoResponse Pagamento { get; set; } = new SimuladorPagamentoResponse();
    }
}