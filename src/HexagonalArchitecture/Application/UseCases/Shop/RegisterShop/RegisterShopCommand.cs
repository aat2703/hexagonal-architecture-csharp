using HexagonalArchitecture.Application.UseCases.Shop.DataTransferObjects;
using MediatR;

namespace HexagonalArchitecture.Application.UseCases.Shop.RegisterShop
{
    public class RegisterShopCommand : IRequest<Task<ShopData>>
    {
        public string Name { get; set; }
        
        public string Email { get; set; }
        
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