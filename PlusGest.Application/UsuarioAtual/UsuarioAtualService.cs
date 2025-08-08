using Microsoft.AspNetCore.Http;
using PlusGest.Gateway.Application.UsuarioAtual.Classe;
using PlusGest.Gateway.Domain.Entities.Enums.Usuario;
using PlusGest.Gateway.Domain.Presentation.Response.Usuario;
using PlusGest.Gateway.Shared.Exeptions.Forbidden;

namespace PlusGest.Gateway.Application.UsuarioAtual
{
    public class UsuarioAtualService : IUsuarioAtualService
    {
        #region Dependências
        private readonly IHttpContextAccessor _httpContextAccessor; 
        #endregion

        #region Contrutores
        public UsuarioAtualService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        #endregion

        #region Buscar Usuário Atual Pelo Token
        public UsuarioResponse UsuarioAtual()
        {
            var claims = _httpContextAccessor.HttpContext.User.Claims
                .ToDictionary(c => c.Type, c => c.Value);

            var usuario = new UsuarioResponse
            {
                UsuarioId = Guid.TryParse(claims.GetValueOrDefault("UsuarioId"), out var usuarioId)
                                 ? usuarioId : Guid.Empty,
                NomeCompleto = claims.GetValueOrDefault("NomeCompleto", string.Empty),
                CPF = claims.GetValueOrDefault("CPF", string.Empty),
                DataNascimento = DateTime.TryParse(claims.GetValueOrDefault("DataNascimento"), out var dataNasc)
                                 ? dataNasc : DateTime.MinValue,
                EmailCorporativo = claims.GetValueOrDefault("EmailCorporativo", string.Empty),
                Status = Enum.TryParse(claims.GetValueOrDefault("Status"), out EnumStatusUsuario status)
                                 ? status : EnumStatusUsuario.Ativo,
                Departamento = Enum.TryParse(claims.GetValueOrDefault("Departamento"), out EnumDepartamentoUsuario dep)
                                 ? dep : EnumDepartamentoUsuario.Diretoria,
                Funcao = Enum.TryParse(claims.GetValueOrDefault("Funcao"), out EnumFuncaoUsuario fun)
                                 ? fun : EnumFuncaoUsuario.DiretoriaGeral,
                Unidade = Enum.TryParse(claims.GetValueOrDefault("Unidade"), out EnumUnidadeUsuario uni)
                                 ? uni : EnumUnidadeUsuario.LaPlus,
                Login = claims.GetValueOrDefault("Login", string.Empty),
            };

            return usuario ?? new UsuarioResponse();
        }
        #endregion

        #region Permissão do Simulador
        public bool PermissaoSimulador()
        {
            var usuario = UsuarioAtual();

            var permissaoDepartamento =
                usuario.Departamento == EnumDepartamentoUsuario.Diretoria ||
                usuario.Departamento == EnumDepartamentoUsuario.Gerencia ||
                usuario.Departamento == EnumDepartamentoUsuario.Suporte ||
                usuario.Departamento == EnumDepartamentoUsuario.Comercial;

            if (!permissaoDepartamento)
                throw new PlusGestForbiddenException("Usuário não tem permissão para acessar o simulador.");

            var permissaoFuncao =
                usuario.Funcao == EnumFuncaoUsuario.DiretoriaGeral ||
                usuario.Funcao == EnumFuncaoUsuario.GerenciaOperacoes ||
                usuario.Funcao == EnumFuncaoUsuario.Dev ||
                usuario.Funcao == EnumFuncaoUsuario.SuporteTecnico ||
                usuario.Funcao == EnumFuncaoUsuario.ComercialCoodernador ||
                usuario.Funcao == EnumFuncaoUsuario.ComercialBackOffice ||
                usuario.Funcao == EnumFuncaoUsuario.ComercialAuxiliar ||
                usuario.Funcao == EnumFuncaoUsuario.ComercialOperador ||
                usuario.Funcao == EnumFuncaoUsuario.SupervisorComercial;

            if (!permissaoFuncao)
                throw new PlusGestForbiddenException("Usuário não tem permissão para acessar o simulador.");

            return true;
        }

        public bool PerimissaoBuscarSimulacao()
        { 
            var usuario = UsuarioAtual();

            var permissaoDepartamento =
                usuario.Departamento == EnumDepartamentoUsuario.Diretoria ||
                usuario.Departamento == EnumDepartamentoUsuario.Gerencia ||
                usuario.Departamento == EnumDepartamentoUsuario.Suporte ||
                usuario.Departamento == EnumDepartamentoUsuario.Comercial ||
                usuario.Departamento == EnumDepartamentoUsuario.Auditoria ||
                usuario.Departamento == EnumDepartamentoUsuario.Recepcao;

            if (!permissaoDepartamento)
                throw new PlusGestForbiddenException("Usuário não tem permissão para buscar simulações.");

            var permissaoFuncao = 
                usuario.Funcao == EnumFuncaoUsuario.DiretoriaGeral ||
                usuario.Funcao == EnumFuncaoUsuario.GerenciaOperacoes ||
                usuario.Funcao == EnumFuncaoUsuario.Dev ||
                usuario.Funcao == EnumFuncaoUsuario.SuporteTecnico ||
                usuario.Funcao == EnumFuncaoUsuario.ComercialCoodernador ||
                usuario.Funcao == EnumFuncaoUsuario.ComercialBackOffice ||
                usuario.Funcao == EnumFuncaoUsuario.ComercialAuxiliar ||
                usuario.Funcao == EnumFuncaoUsuario.ComercialOperador ||
                usuario.Funcao == EnumFuncaoUsuario.SupervisorComercial ||
                usuario.Funcao == EnumFuncaoUsuario.AuditoriaCoordenador ||
                usuario.Funcao == EnumFuncaoUsuario.AuditoriaAnalista ||
                usuario.Funcao == EnumFuncaoUsuario.RecepcaoSupervisor ||
                usuario.Funcao == EnumFuncaoUsuario.RecepcaoAtendente;

            if (!permissaoFuncao) 
                throw new PlusGestForbiddenException("Usuário não tem permissão para buscar simulações.");

            return true;
        }

        public bool PermissaoDeletarSimulacao()
        {
            var usuario = UsuarioAtual();

            var permissaoDepartamento =
                usuario.Departamento == EnumDepartamentoUsuario.Diretoria ||
                usuario.Departamento == EnumDepartamentoUsuario.Gerencia ||
                usuario.Departamento == EnumDepartamentoUsuario.Suporte ||
                usuario.Departamento == EnumDepartamentoUsuario.Comercial;

            if (!permissaoDepartamento)
                throw new PlusGestForbiddenException("Usuário não tem permissão para deletar uma simulação.");

            var permissaoFuncao =
                usuario.Funcao == EnumFuncaoUsuario.DiretoriaGeral ||
                usuario.Funcao == EnumFuncaoUsuario.GerenciaOperacoes ||
                usuario.Funcao == EnumFuncaoUsuario.Dev ||
                usuario.Funcao == EnumFuncaoUsuario.SuporteTecnico ||
                usuario.Funcao == EnumFuncaoUsuario.ComercialCoodernador ||
                usuario.Funcao == EnumFuncaoUsuario.ComercialBackOffice ||
                usuario.Funcao == EnumFuncaoUsuario.SupervisorComercial;

            if (!permissaoFuncao)
                throw new PlusGestForbiddenException("Usuário não tem permissão para deletar uma simulação.");

            return true;
        }
        #endregion
    }
}