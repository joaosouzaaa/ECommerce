using ECommerce.ShoppingCartServiceAPI.Domain.Handlers.Validation.EntitiesValidation;
using ECommerce.TestShoppingCart.Builders;

namespace ECommerce.TestShoppingCart.UnitTest.Validation
{
    public class ProductValidationTest
    {
<<<<<<< HEAD
        private readonly ProductValidation _validate;
=======
        ProductValidation _validate;
>>>>>>> 5b231b8fb15a9f8ebac1753666011663ed13f599

        public ProductValidationTest()
        {
            _validate = new ProductValidation();
        }

        [Fact(DisplayName = "Product Valid")]
        [Trait("Category", "Product Validation")]
        public async Task ProductValidation_ValidProperties_ReturnSucess()
        {
            var product = ProductBuilder.NewObject().DomainBuilder();

<<<<<<< HEAD
            var result = await _validate.ValidationAsync(product);

            Assert.True(result.Valid);
=======
            var response = await _validate.ValidateAsync(product);

            Assert.True(response.IsValid);
>>>>>>> 5b231b8fb15a9f8ebac1753666011663ed13f599
        }

        [Theory(DisplayName = "Product Invalid")]
        [Trait("Category", "Product Validation")]
        [InlineData("llllllllllllllllllllllCinquentalllllllllllllllllllllllllllllllllllllllllllllll")]
        [InlineData("T")]
<<<<<<< HEAD
        [InlineData("")]
        public async Task ProductValidation_InvalidName_ReturnInvalid(string name)
=======
        public async Task ProductValidationProperties_InvalidName_ReturnsFalse(string name)
>>>>>>> 5b231b8fb15a9f8ebac1753666011663ed13f599
        {
            var product = ProductBuilder.NewObject().WithName(name).DomainBuilder();

<<<<<<< HEAD
            var result = await _validate.ValidationAsync(Product);

            Assert.False(!result.Valid);
=======
            var response = await _validate.ValidateAsync(product);

            Assert.False(response.IsValid);
>>>>>>> 5b231b8fb15a9f8ebac1753666011663ed13f599
        }

        [Theory]
        [InlineData("cento e cinquentalllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        [InlineData("ll")]
        [InlineData("T")]
<<<<<<< HEAD
        [InlineData("")]
        public async Task ProductValidation_InvalidDescription_ReturnInvalid(string description)
=======
        public async Task ProductValidationProperties_InvalidDescription_ReturnsFalse(string description)
>>>>>>> 5b231b8fb15a9f8ebac1753666011663ed13f599
        {
            var product = ProductBuilder.NewObject().WithDescription(description).DomainBuilder();

<<<<<<< HEAD
            var response = await _validate.ValidationAsync(Product);

            Assert.False(!response.Valid);
=======
            var response = await _validate.ValidateAsync(product);

            Assert.False(response.IsValid);
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
>>>>>>> 5b231b8fb15a9f8ebac1753666011663ed13f599
        }
    }
}
