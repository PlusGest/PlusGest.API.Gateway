namespace PlusGest.Domain.Presentation.Request.Simulador.PUT.SimuladorCliente
{
    public class PutSimuladorClienteRequest
    {
        #region Propriedades
        public Guid SimuladorClienteId { get; set; }
        public Guid SimuladorId { get; set; }
        public string NomeCompleto { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty; 
        #endregion
    }
}