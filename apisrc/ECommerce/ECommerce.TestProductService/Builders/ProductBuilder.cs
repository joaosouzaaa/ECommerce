using Bogus;
using Bogus.Extensions;
using ECommerce.ProductServiceAPI.ApplicationService.DTOs.Request.ProductRequest;
using ECommerce.ProductServiceAPI.Domain.Entities;

namespace ECommerce.TestProductService.Builders
{
    public class ProductBuilder
    {
        private int _productId = new Faker().Random.Int(1, 100);
        private byte[]? _image = null;
        private string _name = new Faker().Commerce.ProductName().ClampLength(3, 50);
        private string _description = new Faker().Commerce.ProductDescription().ClampLength(3, 500);
        private string? _otherDetails = new Faker().Commerce.ProductDescription().ClampLength(3, 900);
        private int _quantity = 1;
        decimal _price = decimal.Parse(new Faker().Commerce.Price(100.72m, 9860.11m, 2));
        private ProductType _productType = ProductTypeBuilder.NewObject().DomainBuild();

        public static ProductBuilder NewObject()
        {
            return new ProductBuilder();
        }

        public Product DomainBuild()
        {
            return new Product
            {
                Image = _image,
                Name = _name,
                Description = _description,
                OtherDetails = _otherDetails,
                Quantity = _quantity,
                Price = _price,
                ProductType = _productType,
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now
            };
        }

        public ProductSaveRequest DtoSaveBuild()
        {
            return new ProductSaveRequest
            {
                Image = _image,
                Name = _name,
                Description = _description,
                OtherDetails = _otherDetails,
                Quantity = _quantity,
                Price = _price,
                ProductType = ProductTypeBuilder.NewObject().DtoSaveBuild()
            };
        }

        public ProductUpdateRequest DtoUpdateBuild()
        {
            return new ProductUpdateRequest
            {
                ProductId = _productId,
                Image = _image,
                Name = _name,
                Description = _description,
                OtherDetails = _otherDetails,
                Quantity = _quantity,
                Price = _price,
                ProductType = ProductTypeBuilder.NewObject().DtoUpdateBuild()
            };
        }

        public ProductBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public ProductBuilder WithDescription(string description)
        {
            _description = description;
            return this;
        }

        public ProductBuilder WithOtherDetails(string otherDetails)
        {
            _otherDetails = otherDetails;
            return this;
        }

        public ProductBuilder WithQuantity(int quantity)
        {
            _quantity = quantity;
            return this;
        }

        public ProductBuilder WithPrice(decimal price)
        {
            _price = price;
            return this;
        }
    }
}
