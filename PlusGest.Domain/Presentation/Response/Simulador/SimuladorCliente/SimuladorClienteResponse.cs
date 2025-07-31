namespace PlusGest.Domain.Presentation.Response.Simulador.SimuladorCliente
{
    public class SimuladorClienteResponse
    {
        #region Propriedades
        public Guid SimuladorClienteId { get; set; }
        public Guid SimuladorId { get; set; }
        public string NomeCompleto { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty; 
        #endregion
    }
}