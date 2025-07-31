using Mapster;
using PlusGest.Domain.DTOs.Simulador;
using PlusGest.Domain.DTOs.Simulador.SimuladorCliente;
using PlusGest.Domain.DTOs.Simulador.SimuladorImovel;
using PlusGest.Domain.DTOs.Simulador.SimuladorNegociacao;
using PlusGest.Domain.DTOs.Simulador.SimuladorPagamento;
using PlusGest.Domain.DTOs.Simulador.SimuladorVeiculo;
using PlusGest.Domain.DTOs.Usuario;
using PlusGest.Domain.Entities.Simulador;
using PlusGest.Domain.Entities.Simulador.SimuladorCliente;
using PlusGest.Domain.Entities.Simulador.SimuladorImovel;
using PlusGest.Domain.Entities.Simulador.SimuladorNegociacao;
using PlusGest.Domain.Entities.Simulador.SimuladorPagamento;
using PlusGest.Domain.Entities.Simulador.SimuladorVeiculo;
using PlusGest.Domain.Entities.Usuario;
using PlusGest.Domain.Presentation.Request.Simulador.POST;
using PlusGest.Domain.Presentation.Request.Simulador.POST.SimuladorCliente;
using PlusGest.Domain.Presentation.Request.Simulador.POST.SimuladorImovel;
using PlusGest.Domain.Presentation.Request.Simulador.POST.SimuladorNegociacao;
using PlusGest.Domain.Presentation.Request.Simulador.POST.SimuladorPagamento;
using PlusGest.Domain.Presentation.Request.Simulador.POST.SimuladorVeiculo;
using PlusGest.Domain.Presentation.Request.Simulador.PUT;
using PlusGest.Domain.Presentation.Request.Simulador.PUT.SimuladorCliente;
using PlusGest.Domain.Presentation.Request.Simulador.PUT.SimuladorImovel;
using PlusGest.Domain.Presentation.Request.Simulador.PUT.SimuladorNegociacao;
using PlusGest.Domain.Presentation.Request.Simulador.PUT.SimuladorPagamento;
using PlusGest.Domain.Presentation.Request.Simulador.PUT.SimuladorVeiculo;
using PlusGest.Domain.Presentation.Request.Usuario;
using PlusGest.Domain.Presentation.Response.Simulador;
using PlusGest.Domain.Presentation.Response.Simulador.SimuladorCliente;
using PlusGest.Domain.Presentation.Response.Simulador.SimuladorImovel;
using PlusGest.Domain.Presentation.Response.Simulador.SimuladorNegociacao;
using PlusGest.Domain.Presentation.Response.Simulador.SimuladorPagamento;
using PlusGest.Domain.Presentation.Response.Simulador.SimuladorVeiculo;
using PlusGest.Domain.Presentation.Response.Usuario;

namespace PlusGest.Shared.Mappers
{
    public class MappersClass
    {
        public static void Mappings()
        {
            //Simulador Cliente
            TypeAdapterConfig<PostSimuladorClienteRequest, SimuladorClienteDTO>.NewConfig();
            TypeAdapterConfig<PutSimuladorClienteRequest, SimuladorClienteDTO>
                .NewConfig()
                .Ignore(dest => dest.SimuladorClienteId)
                .Ignore(dest => dest.SimuladorId);
            TypeAdapterConfig<SimuladorClienteDTO, SimuladorClienteEntity>.NewConfig();
            TypeAdapterConfig<SimuladorClienteEntity, SimuladorClienteDTO>.NewConfig();
            TypeAdapterConfig<SimuladorClienteDTO, SimuladorClienteResponse>.NewConfig();

            //Simulador Veiculo
            TypeAdapterConfig<PostSimuladorVeiculoRequest, SimuladorVeiculoDTO>.NewConfig();
            TypeAdapterConfig<PutSimuladorVeiculoRequest, SimuladorVeiculoDTO>
                .NewConfig()
                .Ignore(dest => dest.SimuladorVeiculoId)
                .Ignore(dest => dest.SimuladorId);
            TypeAdapterConfig<SimuladorVeiculoDTO, SimuladorVeiculoEntity>.NewConfig();
            TypeAdapterConfig<SimuladorVeiculoEntity, SimuladorVeiculoDTO>.NewConfig();
            TypeAdapterConfig<SimuladorVeiculoDTO, SimuladorVeiculoResponse>.NewConfig();

            //Simulador Imóvel
            TypeAdapterConfig<PostSimuladorImovelRequest, SimuladorImovelDTO>.NewConfig();
            TypeAdapterConfig<PutSimuladorImovelRequest, SimuladorImovelDTO>
                .NewConfig()
                .Ignore(dest => dest.SimuladorImovelId)
                .Ignore(dest => dest.SimuladorId);
            TypeAdapterConfig<SimuladorImovelDTO, SimuladorImovelEntity>.NewConfig();
            TypeAdapterConfig<SimuladorImovelEntity, SimuladorImovelDTO>.NewConfig();
            TypeAdapterConfig<SimuladorImovelDTO, SimuladorImovelResponse>.NewConfig();

            //Simulador Negociação
            TypeAdapterConfig<PostSimuladorNegociacaoRequest, SimuladorNegociacaoDTO>.NewConfig();
            TypeAdapterConfig<PutSimuladorNegociacaoRequest, SimuladorNegociacaoDTO>
                .NewConfig()
                .Ignore(dest => dest.SimuladorNegociacaoId)
                .Ignore(dest => dest.SimuladorId);
            TypeAdapterConfig<SimuladorNegociacaoDTO, SimuladorNegociacaoEntity>.NewConfig();
            TypeAdapterConfig<SimuladorNegociacaoEntity, SimuladorNegociacaoDTO>.NewConfig();
            TypeAdapterConfig<SimuladorNegociacaoDTO, SimuladorNegociacaoResponse>.NewConfig();

            //Simulador Pagamento
            TypeAdapterConfig<PostSimuladorPagamentoRequest, SimuladorPagamentoDTO>.NewConfig();
            TypeAdapterConfig<PutSimuladorPagamentoRequest, SimuladorPagamentoDTO>
                .NewConfig()
                .Ignore(dest => dest.SimuladorPagamentoId)
                .Ignore(dest => dest.SimuladorId);
            TypeAdapterConfig<SimuladorPagamentoDTO, SimuladorPagamentoEntity>.NewConfig();
            TypeAdapterConfig<SimuladorPagamentoEntity, SimuladorPagamentoDTO>.NewConfig();
            TypeAdapterConfig<SimuladorPagamentoDTO, SimuladorPagamentoResponse>.NewConfig();

            //Simulador
            TypeAdapterConfig<PostSimuladorCompletoRequest, SimuladorDTO>.NewConfig();
            TypeAdapterConfig<PutSimuladorCompletoRequest, SimuladorDTO>
                .NewConfig()
                .Ignore(dest => dest.SimuladorId)
                .Ignore(dest => dest.UsuarioId)
                .Ignore(dest => dest.DataCriacao);
            TypeAdapterConfig<SimuladorDTO, SimuladorEntity>.NewConfig();
            TypeAdapterConfig<SimuladorEntity, SimuladorDTO>.NewConfig();
            TypeAdapterConfig<SimuladorDTO, SimuladorCompletoResponse>.NewConfig();

            //Usuário
            TypeAdapterConfig<UsuarioRequest, UsuarioDTO>.NewConfig();
            TypeAdapterConfig<UsuarioDTO, UsuarioEntity>.NewConfig();
            TypeAdapterConfig<UsuarioEntity, UsuarioDTO>.NewConfig();
            TypeAdapterConfig<UsuarioDTO, UsuarioResponse>.NewConfig();
        }
    }
}