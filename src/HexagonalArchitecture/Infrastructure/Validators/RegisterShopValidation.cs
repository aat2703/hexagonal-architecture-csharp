using FluentValidation;
using HexagonalArchitecture.Infrastructure.Http.Shop.RegisterShop;

namespace HexagonalArchitecture.Infrastructure.Validators;

public class RegisterShopValidation : AbstractValidator<RegisterShopRequest>
{
    public RegisterShopValidation()
    {
        RuleFor(x => x.Email).EmailAddress().NotNull();
        RuleFor(x => x.Name).NotNull().MinimumLength(2);
    }
}