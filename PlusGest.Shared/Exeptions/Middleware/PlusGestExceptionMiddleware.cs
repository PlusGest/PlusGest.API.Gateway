using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using PlusGest.Domain.Presentation.Response.Error;
using PlusGest.Shared.Exeptions.BadRequest;
using PlusGest.Shared.Exeptions.Forbidden;
using System.Net;

namespace PlusGest.Shared.Exeptions.Middleware
{
    public class PlusGestExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public PlusGestExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

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
    }
}
