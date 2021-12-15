using HexagonalArchitecture.Api.Application.UseCases.Shop.DataTransferObjects;
using MediatR;

namespace HexagonalArchitecture.Api.Application.UseCases.Shop.GetShopById
{
    public sealed class GetShopByIdCommand : IRequest<Task<ShopData>>
    {
        public Guid Id { get; init; }

        public static GetShopByIdCommand FromId(Guid id)
        {
            return new GetShopByIdCommand
            {
                Id = id
            };
        }
    }
}