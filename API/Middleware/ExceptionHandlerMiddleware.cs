using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace API.Middleware;

internal sealed class ExceptionHandlerMiddleware : IExceptionHandler
{
    private readonly ILogger<ExceptionHandlerMiddleware> _logger;

    public ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        _logger
            .LogError("An Exception {Message} Occurred at {DateTime}",
                exception.Message,
                DateTime.Now);

        int status = GetStatusCodeFromException(exception);

        var problem = new ProblemDetails()
        {
            Status = status,
            Title = exception.GetType().Name,
            Detail = exception.Message,
            Instance = httpContext.Request.Path,
            Type = exception.GetType().Name,
        };


        httpContext.Response.StatusCode = status;
        await httpContext.Response.WriteAsJsonAsync(problem, cancellationToken);

        return true;
    }

    private static int GetStatusCodeFromException(Exception exception) => exception switch
    {

        _ => StatusCodes.Status500InternalServerError
    };
}