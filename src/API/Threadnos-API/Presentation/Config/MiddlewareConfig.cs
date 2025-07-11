using Threadnos_API.Infrastructure.Middleware;

namespace Threadnos_API.Presentation.Config;

public static class MiddlewareConfig
{
    public static IApplicationBuilder UseCustomMiddlewares(this IApplicationBuilder app)
    {
        app.UseMiddleware<RequestContextMiddleware>();
        app.UseMiddleware<ExceptionMiddleware>();
        return app;
    }
}