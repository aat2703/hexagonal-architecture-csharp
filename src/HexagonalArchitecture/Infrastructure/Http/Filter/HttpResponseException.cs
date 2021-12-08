using HexagonalArchitecture.Infrastructure.Http.Response;
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

        var errors = new List<ErrorModel>();

        errors.Add(new ErrorModel
        {
            Context = context.Exception.Source,
            Message = context.Exception?.Message ?? "ExceptionMessageNotFound"
        });
        
        var response = new ErrorResponse(errors);
        
        context.Result = new OkObjectResult(response);

        context.ExceptionHandled = true;
    }
}
