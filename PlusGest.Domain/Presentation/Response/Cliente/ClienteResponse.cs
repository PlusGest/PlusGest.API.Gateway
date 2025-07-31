using PlusGest.Domain.Entities.Enums.Cliente;

namespace PlusGest.Domain.Presentation.Response.Cliente
{
    public class ClienteResponse
    {
        #region Propriedades
        public Guid ClienteId { get; set; }
        public Guid Usuarioid { get; set; }
        public Guid SimuladorId { get; set; }
        public string? NomeCompleto { get; set; }
        public string? Rg { get; set; }
        public string? Cpf { get; set; }
        public EnumClienteStatus Status { get; set; }
        public DateTime DataNascimento { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }
        public string? Cep { get; set; }
        public string? Endereço { get; set; }
        public int Numero { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public string? FotoUrl { get; set; } 
        #endregion
    }
}