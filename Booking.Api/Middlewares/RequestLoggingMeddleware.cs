using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Serilog;

namespace Booking.Api.Middlewares
{
    public class RequestLoggingMeddleware
    {
        private readonly RequestDelegate _next;

        public RequestLoggingMeddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            Log.Information($"Request ID : [{context.TraceIdentifier}]");
            Log.Information($"Endpoint : [{context.Request.Method}]{context.Request.Path.Value}");
            await _next(context);
        }
    }

    public static class RequestLoggingMiddlewareExtension
    {
        public static IApplicationBuilder UseRequestLoggingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestLoggingMeddleware>();
        }
    }
}