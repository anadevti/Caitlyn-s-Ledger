using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace CaitlynsLedgerAPI.CaitlynsLedger.Domain.Handlers
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            _logger.LogError(exception, "An unexpected error occurred: {Message}", exception.Message);

            var (statusCode, title) = GetErrorDetails(exception);

            var problemDetails = new ProblemDetails
            {
                Title = title,
                Status = statusCode,
                Detail = exception.Message,
                Instance = httpContext.Request.Path
            };

            httpContext.Response.StatusCode = statusCode;
            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

            return true;
        }

        private static (int StatusCode, string Title) GetErrorDetails(Exception exception)
        {
            return exception switch
            {
                ArgumentException => (StatusCodes.Status400BadRequest, "Bad Request"),
               // ArgumentNullException => (StatusCodes.Status400BadRequest, "Bad Request"),
                InvalidOperationException => (StatusCodes.Status400BadRequest, "Invalid Operation"),
                UnauthorizedAccessException => (StatusCodes.Status401Unauthorized, "Unauthorized"),
                NotImplementedException => (StatusCodes.Status501NotImplemented, "Not Implemented"),
                _ => (StatusCodes.Status500InternalServerError, "Internal Server Error")
            };
        }
    }
}