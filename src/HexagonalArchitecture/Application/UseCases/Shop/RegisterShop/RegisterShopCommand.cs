using HexagonalArchitecture.Application.UseCases.Shop.DataTransferObjects;
using MediatR;

namespace HexagonalArchitecture.Application.UseCases.Shop.RegisterShop
{
    public sealed class RegisterShopCommand : IRequest<Task<ShopData>>
    {
        public string Name { get; init; }
        
        public string Email { get; init; }
        
        public static RegisterShopCommand From(string name, string email)
        {
            return new RegisterShopCommand
            {
                Name = name,
                Email = email
            };
        }
    }
}