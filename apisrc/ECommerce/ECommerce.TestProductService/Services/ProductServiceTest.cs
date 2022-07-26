using Bogus;
using ECommerce.ProductServiceAPI.ApplicationService.AutoMapperSettings;
using ECommerce.ProductServiceAPI.ApplicationService.DTOs.Request.ProductRequest;
using ECommerce.ProductServiceAPI.ApplicationService.DTOs.Request.ProductTypeRequest;
using ECommerce.ProductServiceAPI.ApplicationService.Services;
using ECommerce.ProductServiceAPI.Domain.Entities;
using ECommerce.ProductServiceAPI.Domain.Enum;
using ECommerce.ProductServiceAPI.Domain.Extensions;
using ECommerce.ProductServiceAPI.Domain.Handlers.Notification;
using ECommerce.ProductServiceAPI.Domain.Handlers.Validation.ValidationEntities;
using ECommerce.ProductServiceAPI.Domain.Interface.RepositoryContract;
using Moq;
using Xunit;

namespace ECommerce.TestProductService.Services;

public class ProductServiceTest
{
    private Mock<IProductRepository> _productRepository;
    private ProductValidation _validate;
    private NotificationHandler _notification;

    public ProductServiceTest()
    {
        AutoMapperConfigurations.Inicialize();
        _productRepository = new Mock<IProductRepository>();
        _validate = new ProductValidation();
        _notification = new NotificationHandler();
    }

    [Fact(DisplayName = "ProductService SaveAsync")]
    [Trait("Success", "Post / SaveAsync")]
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
        _productRepository.Setup(p => p.SaveRepositoryAsync(It.IsAny<Product>())).Returns(Task.FromResult(true)).Verifiable();
        var productService = new ProductService(_validate, _notification, _productRepository.Object);
        var result = await productService.SaveAsync(dtoSave);


        Assert.True(!_notification.HasNotification());
        Assert.True(result);
        _productRepository.Verify(p => p.SaveRepositoryAsync(It.IsAny<Product>()), Times.Exactly(1));
    }

    [Fact(DisplayName = "ProductService SaveAsync")]
    [Trait("Failed", "Post / SaveAsync")]
    public async Task ProductService_ExecuteSaveAsync_ReturnFail()
    {
        var dtoSave = new ProductSaveRequest
        {
            Image = null,
            Name = "",
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
        _productRepository.Setup(p => p.SaveRepositoryAsync(It.IsAny<Product>())).Returns(Task.FromResult(false)).Verifiable();
        var productService = new ProductService(_validate, _notification, _productRepository.Object);
        var result = await productService.SaveAsync(dtoSave);

        Assert.True(_notification.HasNotification());
        Assert.True(!result);
        _productRepository.Verify(p => p.SaveRepositoryAsync(It.IsAny<Product>()), Times.Exactly(0));
    }
}
