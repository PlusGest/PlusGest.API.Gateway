using PlusGest.Gateway.Domain.Presentation.Request.Cliente;
using PlusGest.Gateway.Domain.Presentation.Response.Cliente;
using PlusGest.Gateway.Domain.Presentation.Response.Pagination;

namespace PlusGest.Gateway.Application.Cliente.Classe
{
    public interface IClienteService
    {
        public Task<ClienteResponse> Adicionar(Guid simuladorId, PostClienteRequest model);
        public Task<PaginationResponse<ClienteResponse>> BuscarClientes(int page, int pageSize, string? clienteId);
        public Task<ClienteResponse> BuscarClienteById(Guid clienteId);
        public Task AlterarCliente(Guid clienteId, ClienteRequest model);
        public Task DeletarCliente(Guid clienteId);
    }
}