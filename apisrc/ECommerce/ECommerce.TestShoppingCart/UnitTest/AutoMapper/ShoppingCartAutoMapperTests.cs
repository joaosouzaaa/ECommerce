using ECommerce.ShoppingCartServiceAPI.ApplicationService.AutoMapperSettings;
using ECommerce.ShoppingCartServiceAPI.ApplicationService.Request;
using ECommerce.ShoppingCartServiceAPI.ApplicationService.Response;
using ECommerce.ShoppingCartServiceAPI.Domain.Entities;
using ECommerce.ShoppingCartServiceAPI.Domain.Extensions;
using ECommerce.TestShoppingCart.Builders;

namespace ECommerce.TestShoppingCart.UnitTest.AutoMapper
{
    public class ShoppingCartAutoMapperTests
    {
        public ShoppingCart ShoppingCart = ShoppingCartBuilder.NewObject().DomainBuilder();

        public ShoppingCartAutoMapperTests()
        {
            AutoMapperConfigurations.Inicialize();
        }

        [Fact]
        public void ShoppingCart_To_ShoppingCartSaveRequest()
        {
            var shoppingCartSaveRequest = ShoppingCart.MapTo<ShoppingCart, ShoppingCartSaveRequest>();

            Assert.Equal(shoppingCartSaveRequest.ProductsSaveRequest.Count, ShoppingCart.Products.Count);
        }

        [Fact]
        public void ShoppingCart_To_ShoppingCartResponse()
        {
            var shoppingCartResponse = ShoppingCart.MapTo<ShoppingCart, ShoppingCartResponse>();

            Assert.Equal(shoppingCartResponse.Id, ShoppingCart.Id);
            Assert.Equal(shoppingCartResponse.TotalPrice, ShoppingCart.TotalPrice);
            Assert.Equal(shoppingCartResponse.TotalItens, ShoppingCart.TotalItens);
            Assert.Equal(shoppingCartResponse.ProductsResponse.Count, ShoppingCart.Products.Count);
        }
    }
}
