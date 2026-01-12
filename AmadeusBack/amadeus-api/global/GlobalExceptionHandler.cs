using amadeus_api.exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
namespace amadeus_api.global;

public class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var statusCode = exception switch
        {
            LoginException => StatusCodes.Status403Forbidden,
            ArgumentException => StatusCodes.Status400BadRequest,
            UnauthorizedAccessException => StatusCodes.Status401Unauthorized,
            _ => 500
        };

        var problemDetails = new ProblemDetails
        {
            Title = exception.Message,
            Detail = exception.Message,
            Status = statusCode,
            Type = exception.GetType().Name,
            Instance = httpContext.Request.Path
        };

        httpContext.Response.ContentType = "application/problem+json";
        httpContext.Response.StatusCode = statusCode;

        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }
    /*
    private readonly ILog _log;

    public GlobalExceptionHandler(ILog log)
    {
        _log = log;
    }

    public Task<ProblemDetails> HandleExceptionAsync(ExceptionContext context, Exception exception)
    {
        _log.Error("An unhandled exception occurred.", exception);

        var problemDetails = new ProblemDetails
        {
            Title = "An unexpected error occurred.",
            Status = StatusCodes.Status500InternalServerError,
            Detail = exception.Message
        };

        return Task.FromResult(problemDetails);
    }
    */
}