using PlusGest.Domain.Presentation.Request.Simulador.POST;
using PlusGest.Domain.Presentation.Request.Simulador.POST.SimuladorImovel;
using PlusGest.Domain.Presentation.Request.Simulador.POST.SimuladorVeiculo;
using PlusGest.Domain.Presentation.Request.Simulador.PUT;
using PlusGest.Domain.Presentation.Response.Pagination;
using PlusGest.Domain.Presentation.Response.Simulador;
using PlusGest.Domain.Presentation.Response.Simulador.SimulacaoImovel;
using PlusGest.Domain.Presentation.Response.Simulador.SimulacaoVeiculo;

namespace PlusGest.Application.Simulador.Classes
{
    public interface ISimuladorService
    {
        public Task<SimuladorCompletoResponse> AdicionarSimulacao(PostSimuladorCompletoRequest model);
        public Task<SimuladorCompletoResponse> BuscarSimulacaoById(Guid simuladorId);
        public Task<PaginationResponse<SimuladorCompletoResponse>> BuscarSimulacoes(int page, int pageSize, Guid? simuladorId);
        public Task<SimuladorCompletoResponse> EditarSimulacao(Guid simuladorId, PutSimuladorCompletoRequest model);
        public Task DeletarSimulacao(Guid simuladorId);
        public Task<SimulacaoVeiculoResponse> SimulacaoVeiculo(PostSimuladorVeiculoRequest model);
        public Task<SimulacaoImovelResponse> SimulacaoImovel(PostSimuladorImovelRequest model);
        public Task SimulacaoConcluida();
    }
}