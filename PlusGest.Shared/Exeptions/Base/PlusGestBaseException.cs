namespace PlusGest.Gateway.Shared.Exeptions.Base
{
    public class PlusGestBaseException : Exception
    {
        #region Propriedades
        public int StatusCode { get; }
        #endregion

        #region Construtor Base
        public PlusGestBaseException(int statusCode, string message) : base(message)
        {
            statusCode = StatusCode;
        } 
        #endregion
    }
}