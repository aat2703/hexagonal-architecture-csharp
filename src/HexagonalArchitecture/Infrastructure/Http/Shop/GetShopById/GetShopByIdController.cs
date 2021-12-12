using HexagonalArchitecture.Application.UseCases.Shop.GetShopById;
using HexagonalArchitecture.Infrastructure.Http.Shop.RegisterShop;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HexagonalArchitecture.Infrastructure.Http.Shop.GetShopById;

public sealed class GetShopByIdController : Controller
{
    private readonly IMediator _mediator;

    public GetShopByIdController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("/shops/{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RegisterShopResponse))]
    public async Task<IActionResult> Handle(Guid id)
    {
        var command = GetShopByIdCommand.FromId(id);
            
        var result = await _mediator.Send(command).Result;
        
        return Ok(GetShopByIdResponse.FromShopData(result));
    }
}