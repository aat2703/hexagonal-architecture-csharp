using System.Threading.Tasks;
using MediatR;

namespace HexagonalArchitecture.Application.Shop.RegisterShop
{
    public class RegisterShopCommand : IRequest<Task<Domain.Shop.Entity.Shop>>
    {
        public string Name { get; }

        private RegisterShopCommand(string name)
        {
            Name = name;
        }
        
        public static RegisterShopCommand From(string name)
        {
            return new RegisterShopCommand(name);
        }
    }
}