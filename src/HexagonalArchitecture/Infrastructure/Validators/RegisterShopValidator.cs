using FluentValidation;
using HexagonalArchitecture.Infrastructure.Http.Shop.RegisterShop;

namespace HexagonalArchitecture.Infrastructure.Validators;

public sealed class RegisterShopValidator : AbstractValidator<RegisterShopRequest>
{
    public RegisterShopValidator()
    {
        RuleFor(x => x.Email).EmailAddress().NotNull();
        RuleFor(x => x.Name).NotNull().MinimumLength(2);
    }
}