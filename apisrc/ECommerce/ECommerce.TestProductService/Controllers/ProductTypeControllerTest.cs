using ECommerce.ProductServiceAPI.Controllers;
using ECommerce.ProductServiceAPI.Domain.Interface.ServiceContract;
using ECommerce.TestProductService.Builders;
using Moq;
using Xunit;

namespace ECommerce.TestProductService.Controllers
{
    public class ProductTypeControllerTest
    {
        private Mock<IProductTypeService> _productTypeService;
        private ProductTypeController _controller;

        public ProductTypeControllerTest()
        {
            _productTypeService = new Mock<IProductTypeService>();
            _controller = new ProductTypeController(_productTypeService.Object);
        }

        [Fact(DisplayName = "ProductTypeController")]
        [Trait("Execute method", "Post success")]
        public async Task ProductTypeController_ExecutePost_ReturnSuccess()
        {
            var dtoSave = ProductTypeBuilder.NewObject().DtoSaveBuild();
            _productTypeService.Setup(pt => pt.SaveAsync(dtoSave)).Returns(Task.FromResult(true));

            var controllerResult = await _controller.Post(dtoSave);

            Assert.True(controllerResult);
            _productTypeService.Verify(pt => pt.SaveAsync(dtoSave), Times.Once);
        }


        [Fact(DisplayName = "ProductTypeController")]
        [Trait("Execute method", "Post failed")]
        public async Task ProductTypeController_ExecutePost_ReturnFailed()
        {
            var dtoSave = ProductTypeBuilder.NewObject().DtoSaveBuild();
            _productTypeService.Setup(pt => pt.SaveAsync(dtoSave)).Returns(Task.FromResult(false));

            var controllerResult = await _controller.Post(dtoSave);

            Assert.False(controllerResult);
            _productTypeService.Verify(pt => pt.SaveAsync(dtoSave), Times.Once);
        }

        [Fact(DisplayName = "ProductTypeController")]
        [Trait("Execute method", "Put success")]
        public async Task ProductTypeController_ExecutePut_ReturnSuccess()
        {
            var dtoUpdate = ProductTypeBuilder.NewObject().DtoUpdateBuild();
            _productTypeService.Setup(pt => pt.UpdateAsync(dtoUpdate)).Returns(Task.FromResult(true));

            var controllerResult = await _controller.Put(dtoUpdate);

            Assert.True(controllerResult);
            _productTypeService.Verify(pt => pt.UpdateAsync(dtoUpdate), Times.Once);
        }

        [Fact(DisplayName = "ProductTypeController")]
        [Trait("Execute method", "Put failed")]
        public async Task ProductTypeController_ExecutePut_ReturnFailed()
        {
            var dtoUpdate = ProductTypeBuilder.NewObject().DtoUpdateBuild();
            _productTypeService.Setup(pt => pt.UpdateAsync(dtoUpdate)).Returns(Task.FromResult(false));

            var controllerResult = await _controller.Put(dtoUpdate);

            Assert.False(controllerResult);
            _productTypeService.Verify(pt => pt.UpdateAsync(dtoUpdate), Times.Once);
        }


        [Fact(DisplayName = "ProductTypeController")]
        [Trait("Execute method", "Delete success")]
        public async Task ProductTypeController_ExecuteDelete_ReturnSuccess()
        {
            var productTypeId = 10;
            _productTypeService.Setup(pt => pt.DeleteAsync(productTypeId)).Returns(Task.FromResult(true));

            var controllerResult = await _controller.Delete(productTypeId);

            Assert.True(controllerResult);
            _productTypeService.Verify(pt => pt.DeleteAsync(productTypeId), Times.Once);
        }

        [Fact(DisplayName = "ProductTypeController")]
        [Trait("Execute method", "Delete failed")]
        public async Task ProductTypeController_ExecuteDelete_Returnfailed()
        {
            var productTypeId = 10;
            _productTypeService.Setup(pt => pt.DeleteAsync(productTypeId)).Returns(Task.FromResult(false));

            var controllerResult = await _controller.Delete(productTypeId);

            Assert.False(controllerResult);
            _productTypeService.Verify(pt => pt.DeleteAsync(productTypeId), Times.Once);
        }
    }
}
