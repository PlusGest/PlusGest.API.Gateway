using PlusGest.Gateway.Domain.Entities.Enums.Usuario;

namespace PlusGest.Gateway.Domain.Presentation.Request.Usuario
{
    public class PostUsuarioRequest
    {
        #region Propriedades
        public string NomeCompleto { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public string EmailCorporativo { get; set; } = string.Empty;
        public EnumStatusUsuario Status { get; set; }
        public EnumDepartamentoUsuario Departamento { get; set; }
        public EnumFuncaoUsuario Funcao { get; set; }
        public EnumUnidadeUsuario Unidade { get; set; }
        public string Login { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public string? FotoUrl { get; set; }
        #endregion
    }
}