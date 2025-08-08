using PlusGest.Gateway.Shared.Exeptions.Base;

namespace PlusGest.Gateway.Shared.Exeptions.BadRequest
{
    public class PlusGestBadRequestException : PlusGestBaseException
    {
        #region Status Code
        private const int statusCode = 400;
        #endregion

        #region Construtor Base
        public PlusGestBadRequestException(string message) : base(statusCode, message)
        {
        } 
        #endregion
    }
}