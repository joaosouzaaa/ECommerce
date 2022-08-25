using ECommerce.ShoppingCartServiceAPI.ApplicationService.Request;
using ECommerce.ShoppingCartServiceAPI.ApplicationService.Response;
using ECommerce.ShoppingCartServiceAPI.Controllers;
using ECommerce.ShoppingCartServiceAPI.Domain.Interface.ServiceContract;
using ECommerce.TestShoppingCart.Builders;

namespace ECommerce.TestShoppingCart.UnitTest.Controller
{
    public class ShoppingCartControllerTests
    {
        Mock<IShoppingCartService> _service;
        ShoppingCartController _controller;

        public ShoppingCartControllerTests()
        {
            _service = new Mock<IShoppingCartService>();
            _controller = new ShoppingCartController(_service.Object);
        }

        [Fact]
        public async Task SetAsync_ReturnsTrue()
        {
            var shoppingCarSaveRequest = ShoppingCartBuilder.NewObject().SaveRequestBuilder();
            _service.Setup(s => s.SetAsync(shoppingCarSaveRequest)).Returns(Task.FromResult(true));

            var controllerResult = await _controller.SetAsync(shoppingCarSaveRequest);

            _service.Verify(s => s.SetAsync(shoppingCarSaveRequest), Times.Once());
            Assert.True(controllerResult);
        }

        [Fact]
        public async Task SetAsync_ReturnsFalse()
        {
            var shoppingCarSaveRequest = ShoppingCartBuilder.NewObject().SaveRequestBuilder();
            _service.Setup(s => s.SetAsync(shoppingCarSaveRequest)).Returns(Task.FromResult(false));

            var controllerResult = await _controller.SetAsync(shoppingCarSaveRequest);

            _service.Verify(s => s.SetAsync(shoppingCarSaveRequest), Times.Once());
            Assert.False(controllerResult);
        }

        [Fact]
        public async Task GetAsync_ReturnsEntity()
        {
            var key = Guid.NewGuid().ToString();
            var shoppingCartResponse = ShoppingCartBuilder.NewObject().ResponseBuilder();
            _service.Setup(s => s.GetAsync(key)).Returns(Task.FromResult(shoppingCartResponse));

            var controllerResult = await _controller.GetAsync(key);

            _service.Verify(s => s.GetAsync(key), Times.Once());
            Assert.Equal(controllerResult, shoppingCartResponse);
        }

        [Fact]
        public async Task GetAsync_ReturnsNull()
        {
            var key = Guid.NewGuid().ToString();
            _service.Setup(s => s.GetAsync(key)).Returns(Task.FromResult<ShoppingCartResponse>(null));

            var controllerResult = await _controller.GetAsync(key);

            _service.Verify(s => s.GetAsync(key), Times.Once());
            Assert.Equal(controllerResult, null);
        }

        [Fact]
        public async Task RefreshAsync_ReturnsTrue()
        {
            var key = Guid.NewGuid().ToString();
            _service.Setup(s => s.RefreshAsync(key)).Returns(Task.FromResult(true));

            var controllerResult = await _controller.RefreshAsync(key);
            
            _service.Verify(s => s.RefreshAsync(key), Times.Once());
            Assert.True(controllerResult);
        }

        [Fact]
        public async Task RefreshAsync_ReturnsFalse()
        {
            var key = Guid.NewGuid().ToString();
            _service.Setup(s => s.RefreshAsync(key)).Returns(Task.FromResult(false));

            var controllerResult = await _controller.RefreshAsync(key);

            _service.Verify(s => s.RefreshAsync(key), Times.Once());
            Assert.False(controllerResult);
        }

        [Fact]
        public async Task RemoveAsync_ReturnsTrue()
        {
            var key = Guid.NewGuid().ToString();
            _service.Setup(s => s.RemoveAsync(key)).Returns(Task.FromResult(true));

            var controllerResult = await _controller.RemoveAsync(key);

            _service.Verify(s => s.RemoveAsync(key), Times.Once());
            Assert.True(controllerResult);
        }

        [Fact]
        public async Task RemoveAsync_ReturnsFalse()
        {
            var key = Guid.NewGuid().ToString();
            _service.Setup(s => s.RemoveAsync(key)).Returns(Task.FromResult(false));

            var controllerResult = await _controller.RemoveAsync(key);

            _service.Verify(s => s.RemoveAsync(key), Times.Once());
            Assert.False(controllerResult);
        }
    }
}
