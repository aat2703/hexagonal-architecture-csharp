using HexagonalArchitecture.Application.UseCases.Shop.RegisterShop;
using HexagonalArchitecture.Infrastructure.Http.Filter;
using HexagonalArchitecture.Infrastructure.Http.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HexagonalArchitecture.Infrastructure.Http.Shop.RegisterShop;

public class RegisterShopController : Controller
{
    private readonly IMediator _mediator;
    
    public RegisterShopController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost("/shops")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(RegisterShopResponse))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ErrorResponse))]
    [RequestValidation]
    public async Task<IActionResult> Handle([FromBody] RegisterShopRequest request)
    {
        var command = RegisterShopCommand.From(request.Name, request.Email);
            
        var task = await _mediator.Send(command);
        
        return Created(new Uri("/shops/" + task.Id), RegisterShopResponse.FromShopData(task.Result));
    }
}