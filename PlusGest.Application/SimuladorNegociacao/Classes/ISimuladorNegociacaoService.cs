using PlusGest.Domain.Presentation.Request.Simulador.POST.SimuladorNegociacao;
using PlusGest.Domain.Presentation.Request.Simulador.PUT.SimuladorNegociacao;
using PlusGest.Domain.Presentation.Response.Simulador.SimuladorNegociacao;

namespace PlusGest.Application.SimuladorNegociacao.Classes
{
    public interface ISimuladorNegociacaoService
    {
        public Task<List<SimuladorNegociacaoResponse>> AdicionarNegociacao(Guid simualdorId, ICollection<PostSimuladorNegociacaoRequest> model);
        public Task<List<SimuladorNegociacaoResponse>> ObterNegociacoes(Guid simuladorId);
        public Task<List<SimuladorNegociacaoResponse>> EditarNegociacoes(Guid simuladorId, ICollection<PutSimuladorNegociacaoRequest> model);
    }
}