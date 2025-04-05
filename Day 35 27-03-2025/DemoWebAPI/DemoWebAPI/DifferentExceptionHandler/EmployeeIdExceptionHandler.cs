using DemoWebAPI.Exceptions;
using DemoWebAPI.Model;
using Microsoft.AspNetCore.Diagnostics;

namespace DemoWebAPI.DifferentExceptionHandler
{
    public class EmployeeIdExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is  IdNotFoundException) 
            {
                ErrorResponse errorResponse = new ErrorResponse()
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    ErrorName = "Id Not Found",
                    ErrorDescription = exception.Message
                };
                await httpContext.Response.WriteAsJsonAsync(errorResponse);
                return true;
            }
            return false;


        }
    }
}
