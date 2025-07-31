namespace PlusGest.Domain.Presentation.Request.Autenticar
{
    public class AutenticarRequest
    {
        #region Propriedades
        public string NomeUsuario { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty; 
        #endregion
    }
}