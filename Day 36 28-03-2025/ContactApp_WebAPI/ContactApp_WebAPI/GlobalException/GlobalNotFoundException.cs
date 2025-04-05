using ContactApp_WebAPI.Model.Entity;
using Microsoft.AspNetCore.Diagnostics;

namespace ContactApp_WebAPI.GlobalException
{
    public class GlobalNotFoundException : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, System.Exception exception, CancellationToken cancellationToken)
        {
           if (exception is NullReferenceException)
            {
                var response = new ErrorResponse()
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = "Not Found",
                    ExceptionMessage = exception.Message
                };

                await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);
                return true;
            }
            return false;
        }
    }
}
