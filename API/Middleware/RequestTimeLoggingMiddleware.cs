using System.Diagnostics;

namespace API.Middleware;

public class RequestTimeLoggingMiddleware(ILogger<RequestTimeLoggingMiddleware> logger) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var stopwatch = Stopwatch.StartNew();
        await next.Invoke(context);
        stopwatch.Stop();
        if (stopwatch.ElapsedMilliseconds > 4000)
        {
            logger.LogInformation("Request [{verb}] at {path} took {millisecond}ms",
                context.Request.Method, context.Request.Path, stopwatch.ElapsedMilliseconds);
        }
    }
}