namespace PlusGest.Gateway.Domain.Presentation.Request.Cliente
{
    public class PostClienteRequest
    {
        #region Propriedades
        public Guid ClienteId { get; set; }
        public string NomeCompleto { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty; 
        #endregion
    }
}