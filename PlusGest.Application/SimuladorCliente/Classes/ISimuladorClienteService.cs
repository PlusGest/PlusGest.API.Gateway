using PlusGest.Domain.Presentation.Request.Simulador.POST.SimuladorCliente;
using PlusGest.Domain.Presentation.Request.Simulador.PUT.SimuladorCliente;
using PlusGest.Domain.Presentation.Response.Simulador.SimuladorCliente;

namespace PlusGest.Application.SimuladorCliente.Classes
{
    public interface ISimuladorClienteService
    {
        public Task<SimuladorClienteResponse> AdicionarCliente(Guid simuladorId, PostSimuladorClienteRequest model);
        public Task<SimuladorClienteResponse> ObterCliente(Guid simuladorId);
        public Task<SimuladorClienteResponse> AlterarCliente(Guid simuladorId, Guid simuladorClienteId, PutSimuladorClienteRequest model);
    }
}