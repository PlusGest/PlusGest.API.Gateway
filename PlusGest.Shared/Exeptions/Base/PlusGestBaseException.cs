namespace PlusGest.Shared.Exeptions.Base
{
    public class PlusGestBaseException : Exception
    {
        public int StatusCode { get; }

        public PlusGestBaseException(int statusCode, string message) : base(message)
        {
            statusCode = StatusCode;
        }
    }
}
