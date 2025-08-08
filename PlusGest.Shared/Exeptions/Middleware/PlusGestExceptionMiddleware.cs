using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using PlusGest.Gateway.Domain.Presentation.Response.Error;
using PlusGest.Gateway.Shared.Exeptions.BadRequest;
using PlusGest.Gateway.Shared.Exeptions.Forbidden;
using System.Net;

namespace PlusGest.Gateway.Shared.Exeptions.Middleware
{
    public class PlusGestExceptionMiddleware
    {
        #region Dependências
        private readonly RequestDelegate _next;
        #endregion

        #region Construtores
        public PlusGestExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        #endregion

        #region Invoke Async
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }
        #endregion

        #region Handle Exception 
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var statusCode = (int)HttpStatusCode.InternalServerError;
            string message = exception.Message;

            switch (exception)
            {
                case PlusGestBadRequestException badRequestException:
                    statusCode = (int)HttpStatusCode.BadRequest;
                    message = badRequestException.Message;
                    break;
                case PlusGestForbiddenException forbiddenException:
                    statusCode = (int)HttpStatusCode.Forbidden;
                    message = forbiddenException.Message;
                    break;
                default:
                    statusCode = (int)HttpStatusCode.InternalServerError;
                    message = "An unexpected error occurred.";
                    break;
            }

            var errorResponse = new ErrorResponse
            {
                StatusCode = statusCode,
                Message = message,
                Details = exception.StackTrace
            };

            var errorJson = JsonConvert.SerializeObject(errorResponse);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            return context.Response.WriteAsync(errorJson);
        } 
        #endregion
    }
}