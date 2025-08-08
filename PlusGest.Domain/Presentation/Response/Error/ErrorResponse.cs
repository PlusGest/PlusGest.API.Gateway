namespace PlusGest.Gateway.Domain.Presentation.Response.Error
{
    public class ErrorResponse
    {
        #region Propriedades
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public string? Details { get; set; } 
        #endregion
    }
}