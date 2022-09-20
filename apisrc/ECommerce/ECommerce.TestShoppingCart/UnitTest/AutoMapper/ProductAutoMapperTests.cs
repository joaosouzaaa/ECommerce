using ECommerce.ShoppingCartServiceAPI.ApplicationService.AutoMapperSettings;
using ECommerce.ShoppingCartServiceAPI.ApplicationService.Request;
using ECommerce.ShoppingCartServiceAPI.ApplicationService.Response;
using ECommerce.ShoppingCartServiceAPI.Domain.Entities;
using ECommerce.ShoppingCartServiceAPI.Domain.Extensions;
using ECommerce.TestShoppingCart.Builders;

namespace ECommerce.TestShoppingCart.UnitTest.AutoMapper
{
    public class ProductAutoMapperTests
    {
        public Product Product = ProductBuilder.NewObject().DomainBuilder();

        public ProductAutoMapperTests()
        {
            AutoMapperConfigurations.Inicialize();
        }

        [Fact]
        public void Product_To_ProductSaveRequest()
        {
            var productSaveRequest = Product.MapTo<Product, ProductSaveRequest>();

            Assert.Equal(productSaveRequest.Image, Product.Image);
            Assert.Equal(productSaveRequest.Name, Product.Name);
            Assert.Equal(productSaveRequest.Description, Product.Description);
            Assert.Equal(productSaveRequest.OtherDetails, Product.OtherDetails);
            Assert.Equal(productSaveRequest.Amount, Product.Amount);
            Assert.Equal(productSaveRequest.Price, Product.Price);
        }

        [Fact]
        public void Product_To_ProductResponse()
        {
            var productResponse = Product.MapTo<Product, ProductResponse>();

            Assert.Equal(productResponse.Id, Product.Id);
            Assert.Equal(productResponse.Image, Product.Image);
            Assert.Equal(productResponse.Name, Product.Name);
            Assert.Equal(productResponse.Description, Product.Description);
            Assert.Equal(productResponse.OtherDetails, Product.OtherDetails);
            Assert.Equal(productResponse.Quantity, Product.Amount);
            Assert.Equal(productResponse.Price, Product.Price);
        }
    }
}
