using System.Diagnostics;

namespace DURC.Middlewares;

public class ProfilingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ProfilingMiddleware> _logger;

    /*
     * A middleware is a piece of code that runs for every HTTP request and/or response in the ASP.NET Core pipeline.
     */

    public ProfilingMiddleware(RequestDelegate next, ILogger<ProfilingMiddleware> logger)
    {
        _next   = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        await _next(context);
        stopwatch.Stop();
        _logger.LogInformation($"Request : {context.Request.Path}  took : {stopwatch.ElapsedMilliseconds} ms");
    }

}
