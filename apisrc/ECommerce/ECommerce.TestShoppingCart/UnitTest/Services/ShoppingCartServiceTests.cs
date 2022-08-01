using ECommerce.ShoppingCartServiceAPI.ApplicationService.AutoMapperSettings;
using ECommerce.ShoppingCartServiceAPI.ApplicationService.Service;
using ECommerce.ShoppingCartServiceAPI.Domain.Entities;
using ECommerce.ShoppingCartServiceAPI.Domain.Handlers.Notification;
using ECommerce.ShoppingCartServiceAPI.Domain.Handlers.Validation.EntitiesValidation;
using ECommerce.ShoppingCartServiceAPI.Domain.Interface.RepositoryContract;
using ECommerce.ShoppingCartServiceAPI.RabbitMQSender;
using ECommerce.TestShoppingCart.Builders;

namespace ECommerce.TestShoppingCart.UnitTest.Services
{
    public class ShoppingCartServiceTests
    {
        Mock<IShoppingCartRepository> _repository;
        ShoppingCartValidation _validate;
        NotificationHandler _notification;
        ShoppingCartService _service;
        Mock<IRabbitMQMessageSender> _rabbitMQ;

        public ShoppingCartServiceTests()
        {
            _repository = new Mock<IShoppingCartRepository>();
            _validate = new ShoppingCartValidation();
            _notification = new NotificationHandler();
            _rabbitMQ = new Mock<IRabbitMQMessageSender>();
            _service = new ShoppingCartService(_repository.Object, _validate, _notification, _rabbitMQ.Object);

            AutoMapperConfigurations.Inicialize();
        }

        [Fact]
        public async Task SetAsync_ReturnsTrue()
        {
            var saveRequest = ShoppingCartBuilder.NewObject().SaveRequestBuilder();
            _repository.Setup(r => r.SetAsync(It.IsAny<ShoppingCart>())).Returns(Task.FromResult(true));

            var serviceResult = await _service.SetAsync(saveRequest);

            _repository.Verify(r => r.SetAsync(It.IsAny<ShoppingCart>()), Times.Once());
            Assert.True(serviceResult);
        }

        [Fact]
        public async Task SetAsync_ReturnsFalse()
        {
            var saveRequest = ShoppingCartBuilder.NewObject().SaveRequestBuilder();
            _repository.Setup(r => r.SetAsync(It.IsAny<ShoppingCart>())).Returns(Task.FromResult(false));

            var serviceResult = await _service.SetAsync(saveRequest);

            _repository.Verify(r => r.SetAsync(It.IsAny<ShoppingCart>()), Times.Once());
            Assert.False(serviceResult);
        }

        [Fact]
        public async Task GetAsync_ReturnsEntity()
        {
            var key = Guid.NewGuid().ToString();
            var response = ShoppingCartBuilder.NewObject().ResponseBuilder();
            _repository.Setup(r => r.GetAsync(key)).Returns(Task.FromResult(It.IsAny<ShoppingCart>()));

            var serviceResult = await _service.GetAsync(key);

            _repository.Verify(r => r.GetAsync(key), Times.Once());
            Assert.NotNull(serviceResult);
        }
    }
}
