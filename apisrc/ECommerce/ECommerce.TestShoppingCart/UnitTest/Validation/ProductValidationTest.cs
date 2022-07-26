using ECommerce.ShoppingCartServiceAPI.Domain.Handlers.Validation.EntitiesValidation;
using ECommerce.TestShoppingCart.Builders;

namespace ECommerce.TestShoppingCart.UnitTest.Validation
{
    public class ProductValidationTest
    {
        private readonly ProductValidation _validate;

        public ProductValidationTest()
        {
            _validate = new ProductValidation();
        }

        [Fact(DisplayName = "Product Valid")]
        [Trait("Category", "Product Validation")]
        public async Task ProductValidation_ValidProperties_ReturnSucess()
        {
            var product = ProductBuilder.NewObject()
                    .DomainBuilder();

            var result = await _validate.ValidationAsync(product);

            Assert.True(result.Valid);
        }

        [Theory(DisplayName = "Product Invalid")]
        [Trait("Category", "Product Validation")]
        [InlineData("llllllllllllllllllllllCinquentalllllllllllllllllll")]
        [InlineData("T")]
        [InlineData("")]
        public async Task ProductValidation_InvalidName_ReturnInvalid(string name)
        {
            var Product = ProductBuilder.NewObject()
                    .WithName(name)
                    .DomainBuilder();

            var result = await _validate.ValidationAsync(Product);

            Assert.False(!result.Valid);
        }

        [Theory]
        [InlineData("cento e cinquentalllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllll")]
        [InlineData("ll")]
        [InlineData("T")]
        [InlineData("")]
        public async Task ProductValidation_InvalidDescription_ReturnInvalid(string description)
        {
            var Product = ProductBuilder.NewObject()
                    .WithDescription(description)
                    .DomainBuilder();

            var response = await _validate.ValidationAsync(Product);

            Assert.False(!response.Valid);
        }
    }
}
