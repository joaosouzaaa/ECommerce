using ECommerce.ShoppingCartServiceAPI.Domain.Entities;
using ECommerce.ShoppingCartServiceAPI.Domain.Handlers.Notification;
using ECommerce.ShoppingCartServiceAPI.Domain.Handlers.Validation;
using ECommerce.TestShoppingCart.Builders;

namespace ECommerce.TestShoppingCart.UnitTest.Validation
{
    public class ShoppingCartValidationTest
    {
        private readonly Validate<ShoppingCart> _validate;
        private readonly NotificationHandler _notification;

        public ShoppingCartValidationTest()
        {
            _validate = new Validate<ShoppingCart>();
            _notification = new NotificationHandler();
        }

        [Fact]
        public async Task ShoppingCartPropertiesValidation_Valid_ReturnSucess()
        {
            var cart = ShoppingCartBuilder.NewObject().DomainBuilder();

            await _validate.ValidationAsync(cart);

            Assert.True(!_notification.HasNotification());
        }

        [Theory]
        [InlineData(0.0)]
        [InlineData(-0.1)]
        [InlineData(-1.0)]
        public async Task ShoppingCartPropertiesValidation_Invalid_ReturnHasNotificationTrue(decimal price)
        {
            var cart = ShoppingCartBuilder.NewObject()
                    .WithTotalPrice(price)
                    .DomainBuilder();

            await _validate.ValidationAsync(cart);

            Assert.False(_notification.HasNotification());
        }


    }
}
