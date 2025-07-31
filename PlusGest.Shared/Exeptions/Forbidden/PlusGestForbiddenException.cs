using PlusGest.Shared.Exeptions.Base;

namespace PlusGest.Shared.Exeptions.Forbidden
{
    public class PlusGestForbiddenException : PlusGestBaseException
    {
        private const int statusCode = 403;
        public PlusGestForbiddenException(string message) : base(statusCode, message)
        {
        }
    }
}
