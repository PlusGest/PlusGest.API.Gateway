namespace PlusGest.Domain.Presentation.Response.Autenticar
{
    public class AutenticarResponse
    {
        #region Propriedades
        public string Token { get; set; } = string.Empty;
        public Guid UsuarioId { get; set; } 
        #endregion
    }
}