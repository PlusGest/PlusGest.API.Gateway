using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using PlusGest.Application.SimuladorVeiculo.Classes;
using PlusGest.Domain.Entities.Enums.Simulador;
using PlusGest.Domain.Entities.Simulador.SimuladorVeiculo;
using PlusGest.Domain.Presentation.Request.Simulador.POST.SimuladorVeiculo;
using PlusGest.Domain.Presentation.Request.Simulador.PUT.SimuladorVeiculo;
using PlusGest.Domain.Presentation.Response.Simulador.SimuladorVeiculo;
using PlusGest.Infrastructure.Database;
using PlusGest.Shared.Exeptions.BadRequest;

namespace PlusGest.Application.SimuladorVeiculo
{
    public class SimuladorVeiculoService : ISimuladorVeiculoService
    {
        #region Dependências
        private readonly PlusGestDataContext _plusGestDataContext;
        private readonly IMapper _mapper;
        #endregion

        #region Construtores
        public SimuladorVeiculoService(PlusGestDataContext plusGestDataContext, IMapper mapper)
        {
            _plusGestDataContext = plusGestDataContext;
            _mapper = mapper;
        }
        #endregion

        private bool ValidarDados<T>(T model)
        {
            

            return true;
        }

        #region Adicionar um Veículo
        public async Task<SimuladorVeiculoResponse> AdicionarVeiculo(Guid simuladorId, PostSimuladorVeiculoRequest model)
        {
            if (string.IsNullOrEmpty(model.Veiculo))
                throw new PlusGestBadRequestException("O campo Veículo é obrigatório.");

            if (!Enum.IsDefined(typeof(EnumBancoFinanceira), model.BancoFinanceira))
                throw new PlusGestBadRequestException("O campo Banco/Financeira é inválido.");

            if (model.VencimentoDia < 1 || model.VencimentoDia > 31)
                throw new PlusGestBadRequestException("O campo Vencimento Dia deve ser um valor entre 1 e 31.");

            var validacaoValores =
                model.ValorVeiculo > 0 &&
                model.ValorEntrada >= 0 &&
                model.ValorParcela > 0 &&
                model.TotalParcelas > 0;

            if (!validacaoValores)
                throw new PlusGestBadRequestException("Os valores informados devem ser maiores que zero.");

            var entity = _mapper.Map<SimuladorVeiculoEntity>(model);
            entity.SimuladorId = simuladorId;
            entity.SimuladorVeiculoId = Guid.NewGuid();

            await _plusGestDataContext.AddAsync<SimuladorVeiculoEntity>(entity);

            return _mapper.Map<SimuladorVeiculoResponse>(entity);
        }
        #endregion

        #region Obter Veículo Pelo Id da Simulação
        public async Task<SimuladorVeiculoResponse> ObterVeiculo(Guid simuladorId)
        {
            var entity = await _plusGestDataContext.Set<SimuladorVeiculoEntity>()
                .Where(x => x.SimuladorId == simuladorId)
                .FirstOrDefaultAsync();

            if (entity == null)
                throw new PlusGestBadRequestException("Os dados do veículo não foram encontrados.");

            return _mapper.Map<SimuladorVeiculoResponse>(entity);
        }
        #endregion

        #region Editar um Veículo
        public async Task<SimuladorVeiculoResponse> EditarVeiculo(Guid simuladorId, Guid simuladorVeiculoId, PutSimuladorVeiculoRequest model)
        {
            if (string.IsNullOrEmpty(model.Veiculo))
                throw new PlusGestBadRequestException("O campo Veículo é obrigatório.");

            if (!Enum.IsDefined(typeof(EnumBancoFinanceira), model.BancoFinanceira))
                throw new PlusGestBadRequestException("O campo Banco/Financeira é inválido.");

            if (model.VencimentoDia < 1 || model.VencimentoDia > 31)
                throw new PlusGestBadRequestException("O campo Vencimento Dia deve ser um valor entre 1 e 31.");

            var validacaoValores =
                model.ValorVeiculo > 0 &&
                model.ValorEntrada >= 0 &&
                model.ValorParcela > 0 &&
                model.TotalParcelas > 0;

            if (!validacaoValores)
                throw new PlusGestBadRequestException("Os valores informados devem ser maiores que zero.");

            var entity = await _plusGestDataContext.Set<SimuladorVeiculoEntity>()
                .Where(x => x.SimuladorVeiculoId == simuladorVeiculoId && x.SimuladorId == simuladorId)
                .FirstOrDefaultAsync();

            if (entity == null)
                throw new PlusGestBadRequestException("Os dados do veículo não foram encontrados.");

            var veiculoUpdate = _mapper.Map<SimuladorVeiculoEntity>(model);

            _plusGestDataContext.Update<SimuladorVeiculoEntity>(veiculoUpdate);

            return _mapper.Map<SimuladorVeiculoResponse>(veiculoUpdate);
        }
        #endregion

        #region Calcular Juros Mensal do Veículo
        private decimal CalcularJurosMensal(decimal valorFinanciado, decimal valorParcela, decimal totalParcelas)
        {
            double pv = (double)valorFinanciado;
            double pmt = (double)valorParcela;
            double n = (double)totalParcelas;

            double iMin = 0.0001;
            double iMax = 1.0;
            double i = 0;

            while (iMax - iMin > 0.000001)
            {
                i = (iMin + iMax) / 2;
                double pmtCalc = pv * (i * Math.Pow(1 + i, n)) / (Math.Pow(1 + i, n) - 1);

                if (pmtCalc > pmt)
                    iMax = i;
                else
                    iMin = i;
            }

            var jurosMensal = Math.Round((decimal)i, 6) * 100;
            return jurosMensal;
        }
        #endregion

        #region Gerar Simulação do Veículo
        public Task<SimuladorVeiculoResponse> SimulacaoVeiculo(PostSimuladorVeiculoRequest model)
        {
            if (string.IsNullOrEmpty(model.Veiculo))
                throw new PlusGestBadRequestException("O campo Veículo é obrigatório.");

            if (!Enum.IsDefined(typeof(EnumBancoFinanceira), model.BancoFinanceira))
                throw new PlusGestBadRequestException("O campo Banco/Financeira é inválido.");

            if (model.VencimentoDia < 1 || model.VencimentoDia > 31)
                throw new PlusGestBadRequestException("O campo Vencimento Dia deve ser um valor entre 1 e 31.");

            var validacaoValores =
                model.ValorVeiculo > 0 &&
                model.ValorEntrada >= 0 &&
                model.ValorParcela > 0 &&
                model.TotalParcelas > 0;

            if (!validacaoValores)
                throw new PlusGestBadRequestException("Os valores informados devem ser maiores que zero.");

            var valorFinanciado = model.ValorVeiculo - model.ValorEntrada;
            var totalFinanciamento = model.ValorParcela * model.TotalParcelas;
            var totalJuros = totalFinanciamento - valorFinanciado;
            var jurosMensal = CalcularJurosMensal(valorFinanciado, model.ValorParcela, model.TotalParcelas);
            var jurosFinanciamento = ((totalFinanciamento - valorFinanciado) / valorFinanciado) * 100;
            var parcelasRestantes = model.TotalParcelas - model.ParcelasPagas;
            var valorAberto = model.ValorParcela * parcelasRestantes;
            var valorAtraso = model.ParcelasAtraso * model.ValorParcela;
            var valorFinalBem = model.ValorEntrada + totalFinanciamento;

            return Task.FromResult(new SimuladorVeiculoResponse
            {
                Veiculo = model.Veiculo,
                BancoFinanceira = model.BancoFinanceira,
                ValorVeiculo = model.ValorVeiculo,
                ValorEntrada = model.ValorEntrada,
                ValorParcela = model.ValorParcela,
                TotalParcelas = model.TotalParcelas,
                VencimentoDia = model.VencimentoDia,
                ParcelasPagas = model.ParcelasPagas,
                ParcelasAtraso = model.ParcelasAtraso,
                ValorFinanciado = valorFinanciado,
                TotalFinanciado = totalFinanciamento,
                JurosFinanciado = totalJuros,
                TaxaJuros = jurosFinanciamento,
                ParcelasRestantes = parcelasRestantes,
                ValorAberto = valorAberto,
                ValorAtraso = valorAtraso,
                ValorFinalBem = valorFinalBem
            });
        } 
        #endregion
    }
}