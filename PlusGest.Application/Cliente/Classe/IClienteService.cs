using PlusGest.Domain.Presentation.Request.Cliente;
using PlusGest.Domain.Presentation.Response.Cliente;
using PlusGest.Domain.Presentation.Response.Pagination;

namespace PlusGest.Application.Cliente.Classe
{
    public interface IClienteService
    {
        public Task<PaginationResponse<ClienteResponse>> BuscarClientes(int page, int pageSize, string? clienteId);
        public Task<ClienteResponse> BuscarClienteById(Guid clienteId);
        public Task AlterarCliente(Guid clienteId, ClienteRequest model);
        public Task DeletarCliente(Guid clienteId);
    }
}