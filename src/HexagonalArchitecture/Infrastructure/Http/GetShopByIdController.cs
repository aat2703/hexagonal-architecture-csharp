
using HexagonalArchitecture.Application.UseCases.Shop.GetShopById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HexagonalArchitecture.Infrastructure.Http
{
    public class GetShopByIdController : Controller
    {
        private readonly IMediator _mediator;
        
        public GetShopByIdController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet("/shops/{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ShopViewModel))]
        public async Task<IActionResult> Handle(Guid id)
        {
            var command = GetShopByIdCommand.FromId(id);
            
            var task = await _mediator.Send(command);

            return Ok(new ShopViewModel(task.Result));
        }
    }
}