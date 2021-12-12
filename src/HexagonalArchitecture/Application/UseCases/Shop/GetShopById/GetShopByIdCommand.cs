using HexagonalArchitecture.Application.UseCases.Shop.DataTransferObjects;
using MediatR;

namespace HexagonalArchitecture.Application.UseCases.Shop.GetShopById
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