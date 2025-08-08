using PlusGest.Gateway.Shared.Exeptions.Base;

namespace PlusGest.Gateway.Shared.Exeptions.Forbidden
{
    public class PlusGestForbiddenException : PlusGestBaseException
    {
        #region Status Code
        private const int statusCode = 403;
        #endregion

        #region Construtor Base
        public PlusGestForbiddenException(string message) : base(statusCode, message)
        {
        } 
        #endregion
    }
}