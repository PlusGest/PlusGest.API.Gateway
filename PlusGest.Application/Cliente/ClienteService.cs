using PlusGest.Application.Cliente.Classe;
using PlusGest.Domain.Presentation.Request.Cliente;
using PlusGest.Domain.Presentation.Response.Cliente;
using PlusGest.Domain.Presentation.Response.Pagination;

namespace PlusGest.Application.Cliente
{
    public class ClienteService : IClienteService
    {
        public Task<ClienteResponse> BuscarClienteById(Guid clienteId)
        {
            throw new NotImplementedException();
        }

        public Task<PaginationResponse<ClienteResponse>> BuscarClientes(int page, int pageSize, string? clienteId)
        {
            throw new NotImplementedException();
        }

        public Task AlterarCliente(Guid clienteId, ClienteRequest model)
        {
            throw new NotImplementedException();
        }

        public Task DeletarCliente(Guid clienteId)
        {
            throw new NotImplementedException();
        }
    }
}
