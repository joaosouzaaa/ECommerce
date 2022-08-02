using ECommerce.ProductServiceAPI.ApplicationService.Services;
using ECommerce.ProductServiceAPI.Controllers;
using ECommerce.TestProductService.Builders;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ECommerce.TestProductService.Controllers
{
    public class ProductControllerTest
    {
        private Mock<ProductService> _productService;
        private ProductController _controller;

        public ProductControllerTest()
        {
            _productService = new Mock<ProductService>();
            _controller.ControllerContext = new ControllerContext();
        }

        [Fact(DisplayName = "ProductController")]
        [Trait("Category", "Execute Post")]
        public async Task ProductController_SuccessScenario_ReturnTrue()
        {
            var dtoSave = ProductBuilder.NewObject().DtoSaveBuild();
            _productService.Setup(p => p.SaveAsync(dtoSave)).Returns(Task.FromResult(true));

            var controllerResult = await _controller.SaveAsync(dtoSave);

            Assert.True(controllerResult);
            _productService.Verify(p => p.SaveAsync(dtoSave), Times.Once);
        }
    }
}
