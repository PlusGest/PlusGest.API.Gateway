using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using PlusGest.Application.Simulador.Classes;
using PlusGest.Application.SimuladorCliente.Classes;
using PlusGest.Application.SimuladorImovel.Classes;
using PlusGest.Application.SimuladorNegociacao.Classes;
using PlusGest.Application.SimuladorPagamento.Classes;
using PlusGest.Application.SimuladorVeiculo.Classes;
using PlusGest.Application.UsuarioAtual.Classe;
using PlusGest.Domain.Entities.Enums.Simulador;
using PlusGest.Domain.Entities.Enums.Usuario;
using PlusGest.Domain.Entities.Simulador;
using PlusGest.Domain.Presentation.Request.Simulador.POST;
using PlusGest.Domain.Presentation.Request.Simulador.POST.SimuladorImovel;
using PlusGest.Domain.Presentation.Request.Simulador.POST.SimuladorVeiculo;
using PlusGest.Domain.Presentation.Request.Simulador.PUT;
using PlusGest.Domain.Presentation.Response.Pagination;
using PlusGest.Domain.Presentation.Response.Simulador;
using PlusGest.Domain.Presentation.Response.Simulador.SimulacaoImovel;
using PlusGest.Domain.Presentation.Response.Simulador.SimulacaoVeiculo;
using PlusGest.Domain.Presentation.Response.Simulador.SimuladorImovel;
using PlusGest.Domain.Presentation.Response.Simulador.SimuladorVeiculo;
using PlusGest.Infrastructure.Database;
using PlusGest.Shared.Exeptions.BadRequest;

namespace PlusGest.Application.Simulador
{
    public class SimuladorService : ISimuladorService
    {
        #region Dependências
        private readonly PlusGestDataContext _plusGestDataContext;
        private readonly ISimuladorClienteService _simuladorClienteService;
        private readonly ISimuladorVeiculoService _simuladorVeiculoService;
        private readonly ISimuladorImovelService _simuladorImovelService;
        private readonly IUsuarioAtualService _usuarioAtualService;
        private readonly ISimuladorNegociacaoService _simuladorNegociacaoService;
        private readonly ISimuladorPagamentoService _simuladorPagamentoService;
        private readonly IMapper _mapper;
        #endregion

        #region Construtores
        public SimuladorService(
                PlusGestDataContext plusGestDataContext, 
                IUsuarioAtualService usuarioAtualService, 
                IMapper mapper, 
                ISimuladorClienteService simuladorClienteService, 
                ISimuladorVeiculoService simuladorVeiculoService,
                ISimuladorImovelService simuladorImovelService,
                ISimuladorNegociacaoService simuladorNegociacaoService,
                ISimuladorPagamentoService simuladorPagamentoService
            )
        {
            _plusGestDataContext = plusGestDataContext;
            _usuarioAtualService = usuarioAtualService;
            _mapper = mapper;
            _simuladorClienteService = simuladorClienteService;
            _simuladorVeiculoService = simuladorVeiculoService;
            _simuladorImovelService = simuladorImovelService;
            _simuladorNegociacaoService = simuladorNegociacaoService;
            _simuladorPagamentoService = simuladorPagamentoService;
        }
        #endregion

        #region Adicionar Simulação
        public async Task<SimuladorCompletoResponse> AdicionarSimulacao(PostSimuladorCompletoRequest model)
        {
            _usuarioAtualService.PermissaoSimulador();

            await using var transaction = await _plusGestDataContext.Database.BeginTransactionAsync();

            try
            {
                var entity = _mapper.Map<SimuladorEntity>(model);

                entity.UsuarioId = _usuarioAtualService.UsuarioAtual().UsuarioId;
                entity.SimuladorId = Guid.NewGuid();
                entity.DataCriacao = DateTime.Now;

                await _plusGestDataContext.AddAsync<SimuladorEntity>(entity);

                var cliente = await _simuladorClienteService.AdicionarCliente(entity.SimuladorId, model.Cliente);

                var veiculo = new SimuladorVeiculoResponse();
                var imovel = new SimuladorImovelResponse();

                if (entity.Tipo == EnumSimuladorTipo.Veiculo)
                {
                    veiculo = await _simuladorVeiculoService.AdicionarVeiculo(entity.SimuladorId, model.Veiculo);
                } 
                else
                {
                    imovel = await _simuladorImovelService.AdicionarImovel(entity.SimuladorId, model.Imovel);
                }

                var negociacoes = await _simuladorNegociacaoService.AdicionarNegociacao(entity.SimuladorId, model.Negociacao);
                var pagamento = await _simuladorPagamentoService.AdicionarPagamento(entity.SimuladorId, model.Pagamento);

                await _plusGestDataContext.SaveChangesAsync();
                await transaction.CommitAsync();

                var simulador = _mapper.Map<SimuladorCompletoResponse>(entity);
                simulador.Cliente = cliente;
                simulador.Veiculo = veiculo;
                simulador.Imovel = imovel;
                simulador.Negociacao = negociacoes;
                simulador.Pagamento = pagamento;

                return simulador;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw new PlusGestBadRequestException("Erro ao adicionar a simulção.");
            }
        }
        #endregion

        #region Obter Simulação Por Id
        public async Task<SimuladorCompletoResponse> BuscarSimulacaoById(Guid simuladorId)
        {
            _usuarioAtualService.PerimissaoBuscarSimulacao();

            var entity = await _plusGestDataContext.Set<SimuladorEntity>()
                .Where(x => x.SimuladorId == simuladorId)
                .FirstOrDefaultAsync();

            if (entity == null)
                throw new PlusGestBadRequestException("Simulação não encontrada.");

            var cliente = await _simuladorClienteService.ObterCliente(simuladorId);

            var veiculo = new SimuladorVeiculoResponse();
            var imovel = new SimuladorImovelResponse();

            if (entity.Tipo == EnumSimuladorTipo.Veiculo)
            {
                veiculo = await _simuladorVeiculoService.ObterVeiculo(simuladorId);
            }
            else
            {
                imovel = await _simuladorImovelService.ObterImovel(simuladorId);
            }

            var negociacoes = await _simuladorNegociacaoService.ObterNegociacoes(simuladorId);
            var pagamento = await _simuladorPagamentoService.ObterPagamento(simuladorId);

            var response = _mapper.Map<SimuladorCompletoResponse>(entity);
            response.Cliente = cliente;
            response.Veiculo = veiculo;
            response.Imovel = imovel;
            response.Negociacao = negociacoes;
            response.Pagamento = pagamento;

            return response;
        }
        #endregion

        #region Buscar Todas Simulações
        public async Task<PaginationResponse<SimuladorCompletoResponse>> BuscarSimulacoes(int page, int pageSize, Guid? simuladorId)
        {
            _usuarioAtualService.PermissaoSimulador();

            const int maxPageSize = 10;

            if (pageSize > maxPageSize)
                throw new PlusGestBadRequestException($"O tamanho máximo da página é {maxPageSize}.");

            var query = _plusGestDataContext.Set<SimuladorEntity>()
                .AsQueryable();

            var usuarioComercialOperador =
                _usuarioAtualService.UsuarioAtual().Funcao == EnumFuncaoUsuario.ComercialAuxiliar ||
                _usuarioAtualService.UsuarioAtual().Funcao == EnumFuncaoUsuario.ComercialOperador;

            if (usuarioComercialOperador)
                query = query.Where(x => x.UsuarioId == _usuarioAtualService.UsuarioAtual().UsuarioId);

            if (simuladorId.HasValue)
                query = query.Where(x => x.SimuladorId == simuladorId.Value);

            var totalCount = await query.CountAsync();
            var simulacoes = await query
                .OrderByDescending(x => x.DataCriacao)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToArrayAsync();

            var simulacoesResponse = _mapper.Map<ICollection<SimuladorCompletoResponse>>(simulacoes);

            foreach (var simulacao in simulacoesResponse)
            {
                var cliente = await _simuladorClienteService.ObterCliente(simulacao.SimuladorId);

                var veiculo = new SimuladorVeiculoResponse();
                var imovel = new SimuladorImovelResponse();

                if (simulacao.Tipo == EnumSimuladorTipo.Veiculo)
                {
                    veiculo = await _simuladorVeiculoService.ObterVeiculo(simulacao.SimuladorId);
                }
                else
                {
                    imovel = await _simuladorImovelService.ObterImovel(simulacao.SimuladorId);
                }

                var negociacoes = await _simuladorNegociacaoService.ObterNegociacoes(simulacao.SimuladorId);
                var pagamento = await _simuladorPagamentoService.ObterPagamento(simulacao.SimuladorId);

                simulacao.Cliente = cliente;
                simulacao.Veiculo = veiculo;
                simulacao.Imovel = imovel;
                simulacao.Negociacao = negociacoes;
                simulacao.Pagamento = pagamento;
            }

            return new PaginationResponse<SimuladorCompletoResponse>
            {
                TotalCount = totalCount,
                Page = page,
                PageSize = pageSize,
                List = simulacoesResponse
            };
        }
        #endregion

        #region Editar Simulação
        public async Task<SimuladorCompletoResponse> EditarSimulacao(Guid simuladorId, PutSimuladorCompletoRequest model)
        {
            _usuarioAtualService.PermissaoSimulador();

            var simulacaoExistente = await _plusGestDataContext.Set<SimuladorEntity>()
                .Where(x => x.SimuladorId == simuladorId)
                .FirstOrDefaultAsync();

            if (simulacaoExistente == null)
                throw new PlusGestBadRequestException("Simulação não encontrada.");

            await using var transaction = await _plusGestDataContext.Database.BeginTransactionAsync();

            try
            {
                var simulacao = _mapper.Map<SimuladorEntity>(model);

                _plusGestDataContext.Update<SimuladorEntity>(simulacao);

                var cliente = await _simuladorClienteService.AlterarCliente(simuladorId, model.Cliente.SimuladorClienteId, model.Cliente);
                var veiculo = new SimuladorVeiculoResponse();
                var imovel = new SimuladorImovelResponse();

                if (simulacaoExistente.Tipo == EnumSimuladorTipo.Veiculo)
                {
                    veiculo = await _simuladorVeiculoService.EditarVeiculo(simuladorId, model.Veiculo.SimuladorVeiculoId, model.Veiculo);
                }
                else
                {
                    imovel = await _simuladorImovelService.EditarImovel(simuladorId, model.Imovel.SimuladorImovelId, model.Imovel);
                }

                var negociacoes = await _simuladorNegociacaoService.EditarNegociacoes(simuladorId, model.Negociacao);
                var pagamento = await _simuladorPagamentoService.EditarPagamento(simuladorId, model.Pagamento.SimuladorPagamentoId, model.Pagamento);

                await _plusGestDataContext.SaveChangesAsync();
                await transaction.CommitAsync();

                var simuladorResponse = _mapper.Map<SimuladorCompletoResponse>(simulacao);
                simuladorResponse.Cliente = cliente;
                simuladorResponse.Veiculo = veiculo;
                simuladorResponse.Imovel = imovel;
                simuladorResponse.Negociacao = negociacoes;
                simuladorResponse.Pagamento = pagamento;

                return simuladorResponse;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw new PlusGestBadRequestException("Erro ao editar a simulação.");
            }
        } 
        #endregion

        #region Deleta a Simulação Junto Com Seus Filhos
        public async Task DeletarSimulacao(Guid simuladorId)
        {
            _usuarioAtualService.PermissaoDeletarSimulacao();

            var simulacao = await _plusGestDataContext.Set<SimuladorEntity>()
                .Where(x => x.SimuladorId == simuladorId)
                .FirstOrDefaultAsync();

            if (simulacao == null)
                throw new PlusGestBadRequestException("Simulação não encontrada.");

            _plusGestDataContext.Remove(simulacao);

            await _plusGestDataContext.SaveChangesAsync();

            return;
        } 
        #endregion

        public Task SimulacaoConcluida()
        {
            throw new NotImplementedException();
        }

        public Task<SimulacaoImovelResponse> SimulacaoImovel(PostSimuladorImovelRequest model)
        {
            throw new NotImplementedException();
        }

        public Task<SimulacaoVeiculoResponse> SimulacaoVeiculo(PostSimuladorVeiculoRequest model)
        {
            _usuarioAtualService.PermissaoSimulador();
            throw new NotImplementedException();
        }
    }
}