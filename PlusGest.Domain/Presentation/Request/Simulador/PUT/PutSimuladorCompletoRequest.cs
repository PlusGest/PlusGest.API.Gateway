using PlusGest.Domain.Entities.Enums.Simulador;
using PlusGest.Domain.Presentation.Request.Simulador.PUT.SimuladorCliente;
using PlusGest.Domain.Presentation.Request.Simulador.PUT.SimuladorImovel;
using PlusGest.Domain.Presentation.Request.Simulador.PUT.SimuladorNegociacao;
using PlusGest.Domain.Presentation.Request.Simulador.PUT.SimuladorPagamento;
using PlusGest.Domain.Presentation.Request.Simulador.PUT.SimuladorVeiculo;

namespace PlusGest.Domain.Presentation.Request.Simulador.PUT
{
    public class PutSimuladorCompletoRequest
    {
        #region Propriedades
        public Guid SimuladorId { get; set; }
        public Guid UsuarioId { get; set; }
        public EnumSimuladorTipo Tipo { get; set; }
        public EnumSimuladorStatus Status { get; set; }
        public DateTime DataAtentimento { get; set; }
        public DateTime DataExpriracao { get; set; }
        public bool DadosAnonimizados { get; set; } = false;
        public EnumSimuladorMidia Midia { get; set; }
        public PutSimuladorClienteRequest Cliente { get; set; } = new PutSimuladorClienteRequest();
        public PutSimuladorVeiculoRequest Veiculo { get; set; } = new PutSimuladorVeiculoRequest();
        public PutSimuladorImovelRequest Imovel { get; set; } = new PutSimuladorImovelRequest();
        public ICollection<PutSimuladorNegociacaoRequest> Negociacao { get; set; } = new List<PutSimuladorNegociacaoRequest>();
        public PutSimuladorPagamentoRequest Pagamento { get; set; } = new PutSimuladorPagamentoRequest(); 
        #endregion
    }
}