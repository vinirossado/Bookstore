using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace Book.Infra.CrossCutting.ErrorHandling;

public class GlobalErrorHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if (exception is not ArgumentNullException argumentNullException)
            return false;

        httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
        var data = new { Error = $"Invalid Data: {argumentNullException.ParamName}" };

        await httpContext.Response.WriteAsync(JsonSerializer.Serialize(data), cancellationToken);
        return true;
    }
}