using ECommerce.ShoppingCartServiceAPI.Domain.Entities;
using ECommerce.ShoppingCartServiceAPI.Domain.Handlers.Notification;
using ECommerce.ShoppingCartServiceAPI.Domain.Handlers.Validation;
using ECommerce.TestShoppingCart.Builders;

namespace ECommerce.TestShoppingCart.UnitTest.Validation
{
    public class ProductValidationTest
    {
        private readonly Validate<Product> _validate;
        private readonly NotificationHandler _notification;

        public ProductValidationTest()
        {
            _validate = new Validate<Product>();
            _notification = new NotificationHandler();
        }

        [Fact]
        public async Task ProductValidationProperties_Valid_ReturnSucess()
        {
            var product = ProductBuilder.NewObject()
                    .DomainBuilder();

            await _validate.ValidationAsync(product);

            Assert.True(!_notification.HasNotification());
        }

        [Theory]
        [InlineData("llllllllllllllllllllllCinquentalllllllllllllllllll")]
        [InlineData("T")]
        [InlineData("")]
        public async Task ProductValidationProperties_InvalidName_RetunrHasNotificationTrue(string name)
        {
            var Product = ProductBuilder.NewObject()
                    .WithName(name)
                    .DomainBuilder();

            await _validate.ValidationAsync(Product);

            Assert.False(_notification.HasNotification());
        }

        [Theory]
        [InlineData("cento e cinquentalllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllll")]
        [InlineData("ll")]
        [InlineData("T")]
        [InlineData("")]
        public async Task ProductValidationProperties_InvalidDescription_RetunrHasNotificationTrue(string description)
        {
            var Product = ProductBuilder.NewObject()
                    .WithDescription(description)
                    .DomainBuilder();

            await _validate.ValidationAsync(Product);

            Assert.False(_notification.HasNotification());
        }
    }
}
