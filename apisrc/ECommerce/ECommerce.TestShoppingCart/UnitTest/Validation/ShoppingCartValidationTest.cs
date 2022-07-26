using ECommerce.ShoppingCartServiceAPI.Domain.Entities;
using ECommerce.ShoppingCartServiceAPI.Domain.Handlers.Notification;
using ECommerce.ShoppingCartServiceAPI.Domain.Handlers.Validation;
using ECommerce.ShoppingCartServiceAPI.Domain.Handlers.Validation.EntitiesValidation;
using ECommerce.TestShoppingCart.Builders;

namespace ECommerce.TestShoppingCart.UnitTest.Validation
{
    public class ShoppingCartValidationTest
    {
        ShoppingCartValidation _validate;

        public ShoppingCartValidationTest()
        {
            _validate = new ShoppingCartValidation();
        }

        [Fact(DisplayName = "ShoppingCart Valid")]
        [Trait("Category", "ShoppingCart Validation")]
        public async Task ShoppingCartPropertiesValidation_Valid_ReturnSucess()
        {
            var cart = ShoppingCartBuilder.NewObject().DomainBuilder();

            var response = await _validate.ValidateAsync(cart);

            Assert.True(response.IsValid);
        }

        [Theory(DisplayName = "ShoppingCart Invalid")]
        [Trait("Category", "ShoppingCart Validation")]
        [InlineData(0.0)]
        [InlineData(-0.1)]
        [InlineData(-1.0)]
        public async Task ShoppingCartPropertiesValidation_Invalid_ReturnHasNotificationTrue(decimal price)
        {
            var cart = ShoppingCartBuilder.NewObject().WithTotalPrice(price).DomainBuilder();

            var response = await _validate.ValidateAsync(cart);

            Assert.False(response.IsValid);
        }
    }
}
