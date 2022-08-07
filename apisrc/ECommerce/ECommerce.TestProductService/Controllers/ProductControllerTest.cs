using ECommerce.ProductServiceAPI.ApplicationService.DTOs.Response.ProductResponse;
using ECommerce.ProductServiceAPI.Controllers;
using ECommerce.ProductServiceAPI.Domain.Handlers.Pagination;
using ECommerce.ProductServiceAPI.Domain.Interface.ServiceContract;
using ECommerce.TestProductService.Builders;
using Moq;
using Xunit;

namespace ECommerce.TestProductService.Controllers
{
    public class ProductControllerTest
    {
        private Mock<IProductService> _productService;
        private ProductController _controller;

        public ProductControllerTest()
        {
            _productService = new Mock<IProductService>();
            _controller = new ProductController(_productService.Object);
        }

        [Fact(DisplayName = "ProductController")]
        [Trait("Execute method", "Post Success")]
        public async Task ProductControllerPost_SuccessScenario_ReturnTrue()
        {
            var dtoSave = ProductBuilder.NewObject().DtoSaveBuild();
            _productService.Setup(p => p.SaveAsync(dtoSave)).Returns(Task.FromResult(true));

            var controllerResult = await _controller.SaveAsync(dtoSave);

            Assert.True(controllerResult);
            _productService.Verify(p => p.SaveAsync(dtoSave), Times.Once);
        }

        [Fact(DisplayName = "ProductController")]
        [Trait("Execute method", "Post Failed")]
        public async Task ProductControllerPost_FailedScenario_ReturnFalse()
        {
            var dtoSave = ProductBuilder.NewObject().DtoSaveBuild();
            _productService.Setup(P => P.SaveAsync(dtoSave)).Returns(Task.FromResult(false));

            var controllerResult = await _controller.SaveAsync(dtoSave);

            Assert.False(controllerResult);
            _productService.Verify(p => p.SaveAsync(dtoSave), Times.Once);
        }


        [Fact(DisplayName = "ProductController")]
        [Trait("Execute method", "Put Success")]
        public async Task ProcutControllerPut_SuccessScenario_ReturTrue()
        {
            var dtoUpdate = ProductBuilder.NewObject().DtoUpdateBuild();
            _productService.Setup(p => p.UpdateAsync(dtoUpdate)).Returns(Task.FromResult(true));

            var controllerResult = await _controller.UpdateAsync(dtoUpdate);

            Assert.True(controllerResult);
            _productService.Verify(p => p.UpdateAsync(dtoUpdate), Times.Once);
        }

        [Fact(DisplayName = "ProductController")]
        [Trait("Execute method", "Put Failed")]
        public async Task ProductControllerPut_FailedScenario_ReturnFalse()
        {
            var dtoUpdate = ProductBuilder.NewObject().DtoUpdateBuild();
            _productService.Setup(p => p.UpdateAsync(dtoUpdate)).Returns(Task.FromResult(false));

            var controllerResult = await _controller.UpdateAsync(dtoUpdate);

            Assert.False(controllerResult);
            _productService.Verify(p => p.UpdateAsync(dtoUpdate), Times.Once);
        }

        [Fact(DisplayName = "ProductController")]
        [Trait("Execute method", "Delete Success")]
        public async Task ProductControllerDelete_SuccessScenario_ReturnTrue()
        {
            var productId = 10;
            _productService.Setup(p => p.DeleteAsync(productId)).Returns(Task.FromResult(true));

            var controllerResult = await _controller.DeleteAsync(productId);

            Assert.True(controllerResult);
            _productService.Verify(p => p.DeleteAsync(productId), Times.Once);
        }

        [Fact(DisplayName = "ProductController")]
        [Trait("Execute method", "Delete Failed")]
        public async Task ProductControllerDelete_FailedScenario_ReturnTrue()
        {
            var productId = 10;
            _productService.Setup(p => p.DeleteAsync(productId)).Returns(Task.FromResult(false));

            var controllerResult = await _controller.DeleteAsync(productId);

            Assert.False(controllerResult);
            _productService.Verify(p => p.DeleteAsync(productId), Times.Once);
        }


        [Fact(DisplayName = "ProductController")]
        [Trait("Execute method", "FindBy")]
        public async Task ProductControllerFindBy_SuccessScenario_ReturnProductResponse()
        {
            var productId = 11;
            var response = ProductBuilder.NewObject().DtoSearchResponseBuild();
            _productService.Setup(p => p.FindByAsync(productId)).Returns(Task.FromResult<ProductSearchResponse>(response));

            var objectResponse = await _controller.FindByAsync(productId);

            Assert.Equal(response, objectResponse);
            _productService.Verify(p => p.FindByAsync(productId), Times.Once);
        }


        [Fact(DisplayName = "ProductController")]
        [Trait("Execute method", "FindByWithPagination")]
        public async Task ProductControllerFindByWithPagination_SuccessScenario_ReturnProductResponse()
        {
            var pageParams = PageParamsBuilder.NewObject().DomainBuild();
            var responses = ProductBuilder.NewObject().DtoListSearchResponseBuild();
            _productService.Setup(p => p.FindByWithPagination(pageParams)).Returns(Task.FromResult<PageList<ProductSearchResponse>>(responses));

            var objectResponse = await _controller.FindByWithPaginationAsync(pageParams);

            Assert.True(objectResponse.Result.Any());
            _productService.Verify(p => p.FindByWithPagination(pageParams), Times.Once);
        }
    }
}
