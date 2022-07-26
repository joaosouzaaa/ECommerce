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
            var product = ProductBuilder.NewObject().DomainBuilder();


            var result = await _validate.ValidationAsync(product);

            Assert.True(result.Valid);

            var response = await _validate.ValidateAsync(product);

            Assert.True(response.IsValid);

        }

        [Theory(DisplayName = "Product Invalid")]
        [Trait("Category", "Product Validation")]
        [InlineData("llllllllllllllllllllllCinquentalllllllllllllllllllllllllllllllllllllllllllllll")]
        [InlineData("T")]
        public async Task ProductValidationProperties_InvalidName_ReturnsFalse(string name)

        {
            var product = ProductBuilder.NewObject().WithName(name).DomainBuilder();



            var response = await _validate.ValidationAsync(product);

            Assert.False(response.Valid);

        }

        [Theory]
        [InlineData("cento e cinquentalllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        [InlineData("ll")]
        [InlineData("T")]
        public async Task ProductValidationProperties_InvalidDescription_ReturnsFalse(string description)

        {
            var product = ProductBuilder.NewObject().WithDescription(description).DomainBuilder();

            var response = await _validate.ValidationAsync(product);



            Assert.False(response.Valid);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        public async Task ProductValidationProperties_InvalidQuantity_ReturnsFalse(int quantity)
        {
            var product = ProductBuilder.NewObject().WithQuantity(quantity).DomainBuilder();

            var response = await _validate.ValidateAsync(product);

            Assert.False(response.IsValid);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        public async Task ProductValidationProperties_InvalidPrice_ReturnsFalse(decimal price)
        {
            var product = ProductBuilder.NewObject().WithPrice(price).DomainBuilder();

            var response = await _validate.ValidateAsync(product);

            Assert.False(response.IsValid);
        }

        [Theory]
        [InlineData("a")]
        [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        public async Task ProductValidationProperties_InvalidOtherDetails_ReturnsFalse(string otherDetails)
        {
            var product = ProductBuilder.NewObject().WithOthersDetails(otherDetails).DomainBuilder();

            var response = await _validate.ValidateAsync(product);

            Assert.False(response.IsValid);

        }
    }
}
