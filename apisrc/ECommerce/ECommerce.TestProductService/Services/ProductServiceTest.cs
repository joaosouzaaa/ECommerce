using ECommerce.ProductServiceAPI.ApplicationService.AutoMapperSettings;
using ECommerce.ProductServiceAPI.ApplicationService.DTOs.Request.ProductRequest;
using ECommerce.ProductServiceAPI.ApplicationService.Services;
using ECommerce.ProductServiceAPI.Domain.Entities;
using ECommerce.ProductServiceAPI.Domain.Extensions;
using ECommerce.ProductServiceAPI.Domain.Handlers.Notification;
using ECommerce.ProductServiceAPI.Domain.Handlers.Validation.ValidationEntities;
using ECommerce.ProductServiceAPI.Domain.Interface.RepositoryContract;
using ECommerce.ProductServiceAPI.RabbitMQSender;
using ECommerce.TestProductService.Builders;
using Microsoft.EntityFrameworkCore.Query;
using Moq;
using Xunit;

namespace ECommerce.TestProductService.Services;

public class ProductServiceTest
{
    private Mock<IProductRepository> _productRepository;
    private ProductValidation _validate;
    private NotificationHandler _notification;
    private Mock<IRabbitMQMessageSender> _rabbitMQ;
    private ProductService _productService;

    public ProductServiceTest()
    {
        AutoMapperConfigurations.Inicialize();
        _productRepository = new Mock<IProductRepository>();
        _validate = new ProductValidation();
        _notification = new NotificationHandler();
        _rabbitMQ = new Mock<IRabbitMQMessageSender>();
        _productService = new ProductService(_validate, _notification, _productRepository.Object, _rabbitMQ.Object);
    }

    [Fact(DisplayName = "ProductService")]
    [Trait("Category", "SaveAsync success")]
    public async Task ProductServiceExecuteSaveAsync_SuccessScenario_ReturnSucess()
    {
        var dtoSave = ProductBuilder.NewObject().DtoSaveBuild();

        var product = dtoSave.MapTo<ProductSaveRequest, Product>();
        _productRepository.Setup(p => p.SaveAsync(It.IsAny<Product>())).Returns(Task.FromResult(true)).Verifiable();
        
        var result = await _productService.SaveAsync(dtoSave);

        Assert.True(!_notification.HasNotification());
        Assert.True(result);
        _productRepository.Verify(p => p.SaveAsync(It.IsAny<Product>()), Times.Once);
    }

    [Fact(DisplayName = "ProductService")]
    [Trait("Category", "SaveAsync failed")]
    public async Task ProductServiceExecuteSaveAsync_ExistObjectInDb_ReturnFail()
    {
        var dtoSave = ProductBuilder.NewObject().DtoSaveBuild();
        var product = dtoSave.MapTo<ProductSaveRequest, Product>();
        _productRepository.Setup(p => p.HaveObjectInDbAsync(p => p.Name == dtoSave.Name)).Returns(Task.FromResult(true));
        _productRepository.Setup(p => p.SaveAsync(It.IsAny<Product>())).Returns(Task.FromResult(false)).Verifiable();
        
        var result = await _productService.SaveAsync(dtoSave);

        Assert.True(_notification.HasNotification());
        Assert.True(!result);
        _productRepository.Verify(p => p.SaveAsync(It.IsAny<Product>()), Times.Never);
    }

    [Fact(DisplayName = "ProductService")]
    [Trait("Category", "UpdateAsync success")]
    public async Task ProductServiceExecuteUpdateAsync_SuccessScenario_ReturnSucess()
    {
        var dtoUpdate = ProductBuilder.NewObject().DtoUpdateBuild();
        var product = dtoUpdate.MapTo<ProductUpdateRequest, Product>();
        _productRepository.Setup(p => p.FindByAsync(dtoUpdate.ProductId, null, false)).Returns(Task.FromResult(product));
        _productRepository.Setup(p => p.UpdateAsync(It.IsAny<Product>())).Returns(Task.FromResult(true)).Verifiable();
        
        var result = await _productService.UpdateAsync(dtoUpdate);

        Assert.True(!_notification.HasNotification());
        Assert.True(result);
        _productRepository.Verify(p => p.UpdateAsync(It.IsAny<Product>()), Times.Once);
    }


    [Fact(DisplayName = "ProductService")]
    [Trait("Category", "UpdateAsync failed")]
    public async Task ProductServiceExecuteUpdateAsync_InvalidID_ReturnFail()
    {
        var dtoUpdate = ProductBuilder.NewObject().DtoUpdateBuild();
        var product = dtoUpdate.MapTo<ProductUpdateRequest, Product>();
        _productRepository.Setup(p => p.FindByAsync(dtoUpdate.ProductId, null, false)).Returns(Task.FromResult<Product>(null));
        _productRepository.Setup(p => p.UpdateAsync(It.IsAny<Product>())).Returns(Task.FromResult(true)).Verifiable();
       
        var result = await _productService.UpdateAsync(dtoUpdate);

        Assert.True(_notification.HasNotification());
        Assert.True(!result);
        _productRepository.Verify(p => p.UpdateAsync(It.IsAny<Product>()), Times.Never);
    }

    [Fact(DisplayName = "ProductService")]
    [Trait("Category", "DeleteAsync success")]
    public async Task ProductServiceExecuteDeleteAsync_SuccessScenario_ReturnSucess()
    {
        var id = 10;
        _productRepository.Setup(p => p.HaveObjectInDbAsync(p => p.Id == id)).Returns(Task.FromResult(true));
        _productRepository.Setup(p => p.DeleteAsync(id)).Returns(Task.FromResult(true));

        var requestResult = await _productService.DeleteAsync(id);

        Assert.True(!_notification.HasNotification());
        Assert.True(requestResult);
        _productRepository.Verify(p => p.DeleteAsync(id), Times.Once);
    }


    [Fact(DisplayName = "ProductService")]
    [Trait("Category", "DeleteAsync failed")]
    public async Task ProductServiceExecuteDeleteAsync_InvalidID_ReturnFail()
    {
        var id = 15;
        _productRepository.Setup(p => p.HaveObjectInDbAsync(p => p.Id == id)).Returns(Task.FromResult(false));
        _productRepository.Setup(p => p.DeleteAsync(id)).Returns(Task.FromResult(false));

        var requestResult = await _productService.DeleteAsync(id);

        Assert.True(_notification.HasNotification());
        Assert.True(!requestResult);
        _productRepository.Verify(p => p.DeleteAsync(id), Times.Never);
    }


    [Fact(DisplayName = "ProductService")]
    [Trait("Category", "FindByAsync success")]
    public async Task ProductServiceExecuteFindByAsyn_SuccessScenario_ReturnObject()
    {
        var product = ProductBuilder.NewObject().DomainBuild();
        _productRepository.Setup(p => p.FindByAsync(product.Id, It.IsAny<Func<IQueryable<Product>, IIncludableQueryable<Product, object>>>(), false)).Returns(Task.FromResult(product));

        var requestResult = await _productService.FindByAsync(product.Id);

        _productRepository.Verify(r => r.FindByAsync(product.Id, It.IsAny<Func<IQueryable<Product>, IIncludableQueryable<Product, object>>>(), false), Times.Once());
        Assert.NotNull(requestResult);
    }
}
