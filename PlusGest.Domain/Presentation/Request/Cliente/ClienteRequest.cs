using PlusGest.Domain.Entities.Enums.Cliente;

namespace PlusGest.Domain.Presentation.Request.Cliente
{
    public class ClienteRequest
    {
        #region Propriedades
        public string NomeCompleto { get; set; } = string.Empty;
        public string Rg { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public EnumClienteStatus Status { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Cep { get; set; } = string.Empty;
        public string Endereço { get; set; } = string.Empty;
        public int Numero { get; set; }
        public string Cidade { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public string FotoUrl { get; set; } = string.Empty; 
        #endregion
    }
}