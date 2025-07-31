using PlusGest.Shared.Exeptions.Base;

namespace PlusGest.Shared.Exeptions.BadRequest
{
    public class PlusGestBadRequestException : PlusGestBaseException
    {
        private const int statusCode = 400;

        public PlusGestBadRequestException(string message) : base(statusCode, message)
        {
        }
    }
}
