using ECommerce.ProductServiceAPI.ApplicationService.AutoMapperSettings;
using ECommerce.ProductServiceAPI.ApplicationService.DTOs.Request.ProductTypeRequest;
using ECommerce.ProductServiceAPI.ApplicationService.Services;
using ECommerce.ProductServiceAPI.Domain.Entities;
using ECommerce.ProductServiceAPI.Domain.Extensions;
using ECommerce.ProductServiceAPI.Domain.Handlers.Notification;
using ECommerce.ProductServiceAPI.Domain.Handlers.Validation.ValidationEntities;
using ECommerce.ProductServiceAPI.Domain.Interface.RepositoryContract;
using ECommerce.ProductServiceAPI.RabbitMQSender;
using ECommerce.TestProductService.Builders;
using Moq;
using Xunit;

namespace ECommerce.TestProductService.Services
{
    public class ProductTypeServiceTest
    {
        private Mock<IProductTypeRepository> _productTypeRepository;
        private Mock<IRabbitMQMessageSender> _rabbitMq;
        private ProductTypeService _productTypeService;
        private ProductTypeValidation _validate;
        private NotificationHandler _notificationHandler;

        public ProductTypeServiceTest()
        {
            AutoMapperConfigurations.Inicialize();
            _validate = new ProductTypeValidation();
            _notificationHandler = new NotificationHandler();
            _productTypeRepository = new Mock<IProductTypeRepository>();
            _rabbitMq = new Mock<IRabbitMQMessageSender>();
            _productTypeService = new ProductTypeService(_validate, 
                                                         _notificationHandler ,
                                                         _productTypeRepository.Object,
                                                         _rabbitMq.Object);
        }

        [Fact(DisplayName = "ProductTypeService")]
        [Trait("Execute method", "SaveAsync success")]
        public async Task ProductTypeServiceExecuteSaveAsync_SucessScenario_ReturnTrue()
        {
            var queue = "productTypeQueue";
            var dtoSave = ProductTypeBuilder.NewObject().DtoSaveBuild();
            _productTypeRepository.Setup(pt => pt.HaveObjectInDbAsync(pt => pt.Name == dtoSave.Name)).Returns(Task.FromResult(false));
            //_rabbitMq.Setup(pt => pt.SendMessage(dtoSave, queue)).Verifiable();
            _productTypeRepository.Setup(pt => pt.SaveAsync(It.IsAny<ProductType>())).Returns(Task.FromResult(true));

            var serviceResult = await _productTypeService.SaveAsync(dtoSave);

            Assert.True(serviceResult);
            //_rabbitMq.Verify(pt => pt.SendMessage(dtoSave, queue), Times.Once);
            _productTypeRepository.Verify(pt => pt.HaveObjectInDbAsync(pt => pt.Name == dtoSave.Name), Times.Once);
            _productTypeRepository.Verify(pt => pt.SaveAsync(It.IsAny<ProductType>()), Times.Once);
        }

        [Fact(DisplayName = "ProductTypeService")]
        [Trait("Execute method", "SaveAsync Failed")]
        public async Task ProductTypeServiceExecuteSaveAsync_ExistProductTypeName_ReturnFalse()
        {
            var dtoSave = ProductTypeBuilder.NewObject().DtoSaveBuild();
            _productTypeRepository.Setup(pt => pt.SaveAsync(It.IsAny<ProductType>())).Returns(Task.FromResult(false));
            _productTypeRepository.Setup(pt => pt.HaveObjectInDbAsync(pt => pt.Name == dtoSave.Name)).Returns(Task.FromResult(true));

            var serviceResult = await _productTypeService.SaveAsync(dtoSave);

            Assert.False(serviceResult);
            _productTypeRepository.Verify(pt => pt.HaveObjectInDbAsync(pt => pt.Name == dtoSave.Name), Times.Once);
            _productTypeRepository.Verify(pt => pt.SaveAsync(It.IsAny<ProductType>()), Times.Never);
        }

        [Fact(DisplayName = "ProductTypeService")]
        [Trait("Execute method", "UpdateAsync success")]
        public async Task ProductTypeServiceExecuteUpdateAsync_SucessScenario_ReturnTrue()
        {
            var dtoUpdate = ProductTypeBuilder.NewObject().DtoUpdateBuild();
            var productType = dtoUpdate.MapTo<ProductTypeUpdateRequest, ProductType>();
            _productTypeRepository.Setup(pt => pt.FindByAsync(dtoUpdate.ProductTypeId, null, false)).Returns(Task.FromResult(productType));
            _productTypeRepository.Setup(pt => pt.UpdateAsync(It.IsAny<ProductType>())).Returns(Task.FromResult(true));

            var serviceResult = await _productTypeService.UpdateAsync(dtoUpdate);

            Assert.True(serviceResult);
            _productTypeRepository.Verify(pt => pt.FindByAsync(dtoUpdate.ProductTypeId, null, false), Times.Once);
            _productTypeRepository.Verify(pt => pt.UpdateAsync(It.IsAny<ProductType>()), Times.Once);
        }

        [Fact(DisplayName = "ProductTypeService")]
        [Trait("Execute method", "UpdateAsync failed")]
        public async Task ProductTypeServiceExecuteUpdateAsync_NotFoundProductType_ReturnTrue()
        {
            var dtoUpdate = ProductTypeBuilder.NewObject().DtoUpdateBuild();
            var productType = dtoUpdate.MapTo<ProductTypeUpdateRequest, ProductType>();
            _productTypeRepository.Setup(pt => pt.FindByAsync(dtoUpdate.ProductTypeId, null, false)).Returns(Task.FromResult<ProductType>(null));
            _productTypeRepository.Setup(pt => pt.UpdateAsync(It.IsAny<ProductType>())).Returns(Task.FromResult(false));

            var serviceResult = await _productTypeService.UpdateAsync(dtoUpdate);

            Assert.False(serviceResult);
            _productTypeRepository.Verify(pt => pt.FindByAsync(dtoUpdate.ProductTypeId, null, false), Times.Once);
            _productTypeRepository.Verify(pt => pt.UpdateAsync(It.IsAny<ProductType>()), Times.Never);
        }


        [Fact(DisplayName = "ProductTypeService")]
        [Trait("Execute method", "DeleteAsync success")]
        public async Task ProductTypeServiceExecuteDeleteAsync_SucessScenario_ReturnTrue()
        {
            var productType = 10;
            _productTypeRepository.Setup(pt => pt.HaveObjectInDbAsync(pt => pt.Id == productType)).Returns(Task.FromResult(true));
            _productTypeRepository.Setup(pt => pt.DeleteAsync(productType)).Returns(Task.FromResult(true));

            var serviceResult = await _productTypeService.DeleteAsync(productType);

            Assert.True(serviceResult);
            _productTypeRepository.Verify(pt => pt.HaveObjectInDbAsync(pt => pt.Id == productType), Times.Once);
            _productTypeRepository.Verify(pt => pt.DeleteAsync(productType), Times.Once);
        }

        [Fact(DisplayName = "ProductTypeService")]
        [Trait("Execute method", "DeleteAsync failed")]
        public async Task ProductTypeServiceExecuteDeleteAsync_NotFoundProductType_ReturnTrue()
        {
            var productType = 10;
            _productTypeRepository.Setup(pt => pt.HaveObjectInDbAsync(pt => pt.Id == productType)).Returns(Task.FromResult(false));
            _productTypeRepository.Setup(pt => pt.DeleteAsync(productType)).Returns(Task.FromResult(false));

            var serviceResult = await _productTypeService.DeleteAsync(productType);

            Assert.False(serviceResult);
            _productTypeRepository.Verify(pt => pt.HaveObjectInDbAsync(pt => pt.Id == productType), Times.Once);
            _productTypeRepository.Verify(pt => pt.DeleteAsync(productType), Times.Never);
        }
    }
}
