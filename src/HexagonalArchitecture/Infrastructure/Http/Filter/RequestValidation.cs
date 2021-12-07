using HexagonalArchitecture.Infrastructure.Http.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HexagonalArchitecture.Infrastructure.Http.Filter;

public class RequestValidation : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (context.ModelState.IsValid)
        {
            base.OnActionExecuting(context);
            return;
        }
        
        var response = new ErrorResponse();

        var model = new ErrorModel
        {
            FieldName = "Min besked",
            Message = "Besked"
        };
        
        response.AddError(model);
        
        context.Result = new BadRequestObjectResult(response);
    }
}