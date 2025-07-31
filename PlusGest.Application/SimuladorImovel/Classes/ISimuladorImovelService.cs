using PlusGest.Domain.Presentation.Request.Simulador.POST.SimuladorImovel;
using PlusGest.Domain.Presentation.Request.Simulador.PUT.SimuladorImovel;
using PlusGest.Domain.Presentation.Response.Simulador.SimuladorImovel;

namespace PlusGest.Application.SimuladorImovel.Classes
{
    public interface ISimuladorImovelService
    {
        public Task<SimuladorImovelResponse> AdicionarImovel(Guid simuladorId, PostSimuladorImovelRequest model);
        public Task<SimuladorImovelResponse> ObterImovel(Guid simladorId);
        public Task<SimuladorImovelResponse> EditarImovel(Guid simuladorId, Guid simuladorImovelId, PutSimuladorImovelRequest model);
    }
}