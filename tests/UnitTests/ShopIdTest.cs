using System;
using HexagonalArchitecture.Api.Domain.Shop.Entity;
using Xunit;

namespace Unit;

public class ShopIdTest
{
    [Fact]
    public void TestAShopIdCanBeConstructed()
    {
        var shopId = ShopId.FromGuid(Guid.NewGuid());

        Assert.IsType<ShopId>(shopId);
    }

    [Fact]
    public void TestAShopIdCannotBeParsedFromInvalidString()
    {
        Assert.Throws<FormatException>(() => ShopId.FromString("an-invalid-guid-string"));
    }
}