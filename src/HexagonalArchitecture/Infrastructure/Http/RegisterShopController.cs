using HexagonalArchitecture.Application.Shop.RegisterShop;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HexagonalArchitecture.Infrastructure.Http
{
    public class RegisterShopController : Controller
    {
        private readonly IMediator _mediator;
        
        public RegisterShopController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpPost("/shops")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ShopViewModel))]
        public async Task<IActionResult> Handle([FromBody] RegisterShopRequest request)
        {
            var command = RegisterShopCommand.From(request.Name);
            
            var task = await _mediator.Send(command);
            
            return Created(new Uri("/shops/" + task.Result.Id), new ShopViewModel(task.Result));
        }
    }
}