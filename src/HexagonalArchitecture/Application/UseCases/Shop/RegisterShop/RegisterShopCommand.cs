using HexagonalArchitecture.Application.UseCases.Shop.DataTransferObjects;
using MediatR;

namespace HexagonalArchitecture.Application.UseCases.Shop.RegisterShop
{
    public class RegisterShopCommand : IRequest<Task<ShopData>>
    {
        public string Name { get; }
        
        public string Email { get; }

        private RegisterShopCommand(string name, string email)
        {
            Name = name;
            Email = email;
        }
        
        public static RegisterShopCommand From(string name, string email)
        {
            return new RegisterShopCommand(name, email);
        }
    }
}