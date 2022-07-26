﻿using Bogus;
using Bogus.Extensions;
using ECommerce.ProductServiceAPI.Domain.Handlers.Validation.ValidationEntities;
using ECommerce.TestProductService.Builders;
using Xunit;

namespace ECommerce.TestProductService.Validations
{
    public class ProductValidationTest
    {
        private ProductValidation _validate;


        public static IEnumerable<object[]> DataName =>
           new List<object[]>
           {
                new object[] { new Faker().Commerce.ProductName().ClampLength(0, 1) },
                new object[] { new Faker().Commerce.ProductName().ClampLength(51, 52) },
           };

        public static IEnumerable<object[]> DataDescription =>
          new List<object[]>
          {
                new object[] { new Faker().Commerce.ProductDescription().ClampLength(0, 1) },
                new object[] { new Faker().Commerce.ProductName().ClampLength(501) },
          };

        public static IEnumerable<object[]> DataOtherDetails =>
         new List<object[]>
         {
                new object[] { new Faker().Commerce.ProductDescription().ClampLength(0, 1) },
                new object[] { new Faker().Commerce.ProductName().ClampLength(901) },
         };

        public static IEnumerable<object[]> DataPrice =>
         new List<object[]>
         {
                new object[] { decimal.Parse(new Faker().Commerce.Price(-1.01m, -0.01m)) },
                new object[] { decimal.Parse(new Faker().Commerce.Price(0.00m, 0.00m)) },
         };

        public ProductValidationTest()
        {
            _validate = new ProductValidation();
        }

        [Fact(DisplayName = "Product Validation")]
        [Trait("Sucess", "Valid Properties")]
        public async Task ProductValidation_WithValidProperties_ReturnSucess()
        {
            var product = ProductBuilder.NewObject().DomainBuilder();
                    
            var validateResponse = await _validate.ValidationAsync(product);

            Assert.NotNull(product);
            Assert.True(validateResponse.Valid);
        }

        [Theory(DisplayName = "Product Validation")]
        [MemberData(nameof(DataName))]
        [Trait("Fail", "Invalid Name")]
        public async Task ProductValidation_WithInvalidPropertyName_ReturnFail(string name)
        {
            var product = ProductBuilder.NewObject()
                .WithName(name)
                .DomainBuilder();

            var validateResponse = await _validate.ValidationAsync(product);

            Assert.NotNull(product);
            Assert.True(!validateResponse.Valid);
        }

        [Theory(DisplayName = "Product Validation")]
        [MemberData(nameof(DataDescription))]
        [Trait("Fail", "Invalid Description")]
        public async Task ProductValidation_WithInvalidPropertyDescription_ReturnFail(string description)
        {
            var product = ProductBuilder.NewObject()
                .WithDescription(description)
                .DomainBuilder();

            var validateResponse = await _validate.ValidationAsync(product);

            Assert.NotNull(product);
            Assert.True(!validateResponse.Valid);
        }


        [Theory(DisplayName = "Product Validation")]
        [MemberData(nameof(DataOtherDetails))]
        [Trait("Fail", "Invalid OtherDetails")]
        public async Task ProductValidation_WithInvalidPropertyOtherDetails_ReturnFail(string otherDetails)
        {
            var product = ProductBuilder.NewObject()
                .WithOtherDetails(otherDetails)
                .DomainBuilder();

            var validateResponse = await _validate.ValidationAsync(product);

            Assert.NotNull(product);
            Assert.True(!validateResponse.Valid);
        }

        [Theory(DisplayName = "Product Validation")]
        [MemberData(nameof(DataPrice))]
        [Trait("Fail", "Invalid Price")]
        public async Task ProductValidation_WithInvalidPropertyPrice_ReturnFail(decimal price)
        {
            var product = ProductBuilder.NewObject()
                .WithPrice(price)
                .DomainBuilder();

            var validateResponse = await _validate.ValidationAsync(product);

            Assert.NotNull(product);
            Assert.True(!validateResponse.Valid);
        }
    }
}