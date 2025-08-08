using PlusGest.Gateway.Application.Cliente.Classe;
using PlusGest.Gateway.Domain.Presentation.Request.Cliente;
using PlusGest.Gateway.Domain.Presentation.Response.Cliente;
using PlusGest.Gateway.Domain.Presentation.Response.Pagination;
using PlusGest.Gateway.Shared.Exeptions.BadRequest;
using System.Net;

namespace PlusGest.Gateway.Application.Cliente
{
    public class ClienteService : IClienteService
    {
        #region Dependências
        private readonly HttpClient _httpClient;
        #endregion

        #region Construtores
        public ClienteService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        } 
        #endregion

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

        public async Task<ClienteResponse> Adicionar(Guid simuladorId, PostClienteRequest model)
        {
            var response = await _httpClient.GetAsync($"api/v1/SimuladorCompleto/{simuladorId}");

            if (response.StatusCode == HttpStatusCode.NotFound)
                throw new PlusGestBadRequestException("Simulador não encontrado.");

            if (!response.IsSuccessStatusCode)
                throw new PlusGestBadRequestException("Erro ao consultar a simulação.");

            throw new NotImplementedException();
        }
    }
}