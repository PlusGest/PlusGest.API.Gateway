using PlusGest.Domain.Presentation.Request.Simulador.POST.SimuladorVeiculo;
using PlusGest.Domain.Presentation.Request.Simulador.PUT.SimuladorVeiculo;
using PlusGest.Domain.Presentation.Response.Simulador.SimuladorVeiculo;

namespace PlusGest.Application.SimuladorVeiculo.Classes
{
    public interface ISimuladorVeiculoService
    {
        public Task<SimuladorVeiculoResponse> AdicionarVeiculo(Guid simuladorId, PostSimuladorVeiculoRequest model);
        public Task<SimuladorVeiculoResponse> ObterVeiculo(Guid simuladorId);
        public Task<SimuladorVeiculoResponse> EditarVeiculo(Guid simuladorId, Guid simuladorVeiculoId, PutSimuladorVeiculoRequest model);
        public Task<SimuladorVeiculoResponse> SimulacaoVeiculo(PostSimuladorVeiculoRequest model);
    }
}