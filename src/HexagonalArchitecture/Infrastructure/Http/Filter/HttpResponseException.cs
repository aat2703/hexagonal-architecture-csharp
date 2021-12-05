using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HexagonalArchitecture.Infrastructure.Http.Filter;

public class HttpResponseExceptionFilter : IActionFilter
{
    public int Order => int.MaxValue - 10;

    public void OnActionExecuting(ActionExecutingContext context) { }
    
    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Exception == null)
        {
            return;
        }
        
        context.Result = new OkObjectResult(context.Exception.InnerException?.Message);

        context.ExceptionHandled = true;
    }
}
