namespace PlusGest.Domain.DTOs.Cliente.ClienteObservacao
{
    public class ClienteObservacaoDTO
    {
        #region Propriedades
        public Guid ClienteObservacaoId { get; set; }
        public Guid ClienteId { get; set; }
        public string Obervacao { get; set; } = string.Empty; 
        #endregion
    }
}