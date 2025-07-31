using PlusGest.Domain.Presentation.Request.Simulador.POST.SimuladorPagamento;
using PlusGest.Domain.Presentation.Request.Simulador.PUT.SimuladorPagamento;
using PlusGest.Domain.Presentation.Response.Simulador.SimuladorPagamento;

namespace PlusGest.Application.SimuladorPagamento.Classes
{
    public interface ISimuladorPagamentoService
    {
        public Task<SimuladorPagamentoResponse> AdicionarPagamento(Guid simuladorId, PostSimuladorPagamentoRequest model);
        public Task<SimuladorPagamentoResponse> ObterPagamento(Guid simuladorId);
        public Task<SimuladorPagamentoResponse> EditarPagamento(Guid simuladorId, Guid simuladorPagamentoId, PutSimuladorPagamentoRequest model);
    }
}