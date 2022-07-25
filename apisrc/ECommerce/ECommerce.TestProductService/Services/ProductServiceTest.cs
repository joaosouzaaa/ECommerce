using Bogus;
using ECommerce.ProductServiceAPI.ApplicationService.AutoMapperSettings;
using ECommerce.ProductServiceAPI.ApplicationService.DTOs.Request.ProductRequest;
using ECommerce.ProductServiceAPI.ApplicationService.DTOs.Request.ProductTypeRequest;
using ECommerce.ProductServiceAPI.ApplicationService.Services;
using ECommerce.ProductServiceAPI.Domain.Entities;
using ECommerce.ProductServiceAPI.Domain.Enum;
using ECommerce.ProductServiceAPI.Domain.Extensions;
using ECommerce.ProductServiceAPI.Domain.Handlers.Validation;
using ECommerce.ProductServiceAPI.Domain.Interface;
using ECommerce.ProductServiceAPI.Domain.Interface.RepositoryContract;
using Moq;
using Xunit;

namespace ECommerce.TestProductService.Services;

public class ProductServiceTest
{
    public ProductServiceTest()
    {
        AutoMapperConfigurations.Inicialize();
    }

    [Fact(DisplayName = "ProductService SaveAsync")]
    [Trait("Category", "Post / SaveAsync")]
    public async Task ProductService_ExecuteSaveAsync_ReturnSucess()
    {
        var dtoSave = new ProductSaveRequest
        {
            Image = null,
            Name = new Faker().Commerce.ProductName(),
            Description = new Faker().Commerce.ProductDescription(),
            OtherDetails = new Faker().Commerce.ProductDescription(),
            Quantity = 1,
            Price = decimal.Parse(new Faker().Commerce.Price(100.55m, 9890.86m)),
            Type = new ProductTypeSaveRequest
            {
                Name = new Faker().Commerce.ProductName(),
                Category = ECategory.HomeAppliance
            }
        };

        var product = dtoSave.MapTo<ProductSaveRequest, Product>();

        var productRepository = new Mock<IProductRepository>();
        var notification = new Mock<INotificationHandler>().Object;
        var validate = new Validate<Product>();

        var productService = new ProductService(validate, notification, productRepository.Object);

        await productService.SaveAsync(dtoSave);

        productRepository.Setup(p => p.SaveAsync(product)).Verifiable();
    }
}
