namespace Threadnos_API.Presentation.Middleware
{
    using System;
    using System.Net;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;
    using Threadnos_API.Application.Exceptions;
    using Threadnos_API.Domain.Exceptions;
    using Threadnos_API.Presentation.Contracts;

    namespace YourNamespace.Middlewares
    {
        public class ExceptionMiddleware
        {
            private readonly RequestDelegate _next;
            private readonly ILogger<ExceptionMiddleware> _logger;

            public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
            {
                _next = next;
                _logger = logger;
            }

            public async Task InvokeAsync(HttpContext context)
            {
                try
                {
                    await _next(context);
                }
                catch (AppLayerException aex)
                {
                    _logger.LogWarning(aex, "Application Layer Exception occurred");                    
                    await HandleExceptionAsync(context, aex, aex.StatusCode);
                }
                catch (BusinessException dex)
                {
                    _logger.LogWarning(dex, "Domain Layer Exception occurred");
                    await HandleExceptionAsync(context, dex, HttpStatusCode.BadRequest);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An unhandled exception occurred");
                    await HandleExceptionAsync(context, ex, HttpStatusCode.InternalServerError);
                }
            }

            private static Task HandleExceptionAsync(HttpContext context, Exception exception, HttpStatusCode statusCode)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)statusCode;

                var response = new ErrorResponse
                (
                    context.Response.StatusCode,
                    exception.Message
                );

                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

                var json = JsonSerializer.Serialize(response, options);
                return context.Response.WriteAsync(json);
            }

        }

    }

}
