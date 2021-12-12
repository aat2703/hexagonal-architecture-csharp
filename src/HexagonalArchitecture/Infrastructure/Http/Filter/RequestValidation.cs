using HexagonalArchitecture.Infrastructure.Http.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HexagonalArchitecture.Infrastructure.Http.Filter;

public sealed class RequestValidation : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (context.ModelState.IsValid)
        {
            base.OnActionExecuting(context);
            return;
        }
        
        var errors = context.ModelState.Values.Where(x => x.Errors.Count > 0)
            .SelectMany(x => x.Errors)
            .Select(x => new ErrorModel
            {
                Context = x.Exception?.Source ?? null,
                Message = x.ErrorMessage
            })
            .ToList();
        
        context.Result = new UnprocessableEntityObjectResult(new ErrorResponse(errors));
    }
}