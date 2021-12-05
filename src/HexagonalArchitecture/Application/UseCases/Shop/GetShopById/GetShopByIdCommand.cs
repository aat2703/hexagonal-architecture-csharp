using MediatR;

namespace HexagonalArchitecture.Application.UseCases.Shop.GetShopById
{
    public class GetShopByIdCommand : IRequest<Task<Domain.Shop.Entity.Shop>>
    {
        public Guid Id { get; }

        private GetShopByIdCommand(Guid id)
        {
            Id = id;
        }

        public static GetShopByIdCommand FromId(Guid id)
        {
            return new GetShopByIdCommand(id);
        }
    }
}