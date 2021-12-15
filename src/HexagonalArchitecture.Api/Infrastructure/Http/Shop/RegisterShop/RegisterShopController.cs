using HexagonalArchitecture.Api.Application.UseCases.Shop.RegisterShop;
using HexagonalArchitecture.Api.Infrastructure.Http.Filter;
using HexagonalArchitecture.Api.Infrastructure.Http.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HexagonalArchitecture.Api.Infrastructure.Http.Shop.RegisterShop;

public sealed class RegisterShopController : Controller
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

        var result = await _mediator.Send(command).Result;

        return Created(new Uri("/shops/" + result.Id), RegisterShopResponse.FromShopData(result));
    }
}