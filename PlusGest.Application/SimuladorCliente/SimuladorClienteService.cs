using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using PlusGest.Application.SimuladorCliente.Classes;
using PlusGest.Domain.Entities.Simulador.SimuladorCliente;
using PlusGest.Domain.Presentation.Request.Simulador.POST.SimuladorCliente;
using PlusGest.Domain.Presentation.Request.Simulador.PUT.SimuladorCliente;
using PlusGest.Domain.Presentation.Response.Simulador.SimuladorCliente;
using PlusGest.Infrastructure.Database;
using PlusGest.Shared.Exeptions.BadRequest;

namespace PlusGest.Application.SimuladorCliente
{
    public class SimuladorClienteService : ISimuladorClienteService
    {
        #region Dependências
        private readonly PlusGestDataContext _plusGestDataContext;
        private readonly IMapper _mapper;
        #endregion

        #region Construtores
        public SimuladorClienteService(PlusGestDataContext plusGestDataContext, IMapper mapper)
        {
            _plusGestDataContext = plusGestDataContext;
            _mapper = mapper;
        }
        #endregion

        #region Adicionar um Cliente
        public async Task<SimuladorClienteResponse> AdicionarCliente(Guid simuladorId, PostSimuladorClienteRequest model)
        {
            var entity = _mapper.Map<SimuladorClienteEntity>(model);

            entity.SimuladorClienteId = Guid.NewGuid();
            entity.SimuladorId = simuladorId;

            await _plusGestDataContext.AddAsync<SimuladorClienteEntity>(entity);

            return _mapper.Map<SimuladorClienteResponse>(entity);
        }
        #endregion

        #region Obter Cliente
        public async Task<SimuladorClienteResponse> ObterCliente(Guid simuladorId)
        {
            var entity = await _plusGestDataContext.Set<SimuladorClienteEntity>()
                .Where(x => x.SimuladorId == simuladorId)
                .FirstOrDefaultAsync();

            if (entity == null)
                throw new PlusGestBadRequestException("Clinete da simulação não encontrado.");

            return _mapper.Map<SimuladorClienteResponse>(entity);
        } 
        #endregion

        #region Alterar o Cliente
        public async Task<SimuladorClienteResponse> AlterarCliente(Guid simuladorId, Guid simuladorClienteId, PutSimuladorClienteRequest model)
        {
            var entity = await _plusGestDataContext.Set<SimuladorClienteEntity>()
                .Where(x => x.SimuladorClienteId == simuladorClienteId && x.SimuladorId == simuladorId)
                .FirstOrDefaultAsync();

            if (entity == null)
                throw new PlusGestBadRequestException("Cliente não encontrado.");

            var updatedEntity = _mapper.Map<SimuladorClienteEntity>(model);

            _plusGestDataContext.Update(updatedEntity);

            return _mapper.Map<SimuladorClienteResponse>(updatedEntity);
        } 
        #endregion
    }
}