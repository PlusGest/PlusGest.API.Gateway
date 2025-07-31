using PlusGest.Domain.Entities.Enums.Usuario;

namespace PlusGest.Domain.DTOs.Usuario
{
    public class UsuarioDTO
    {
        #region Propreidades
        public Guid UsuarioId { get; set; }
        public string NomeCompleto { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public EnumStatusUsuario Status { get; set; }
        public EnumDepartamentoUsuario Departamento { get; set; }
        public EnumFuncaoUsuario Funcao { get; set; }
        public EnumUnidadeUsuario Unidade { get; set; }
        public string NomeUsuario { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public string FotoUrl { get; set; } = string.Empty;
        #endregion
    }
}