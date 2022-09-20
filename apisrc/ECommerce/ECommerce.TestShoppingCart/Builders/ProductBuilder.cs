using Bogus;
using ECommerce.ShoppingCartServiceAPI.ApplicationService.Request;
using ECommerce.ShoppingCartServiceAPI.ApplicationService.Response;
using ECommerce.ShoppingCartServiceAPI.Domain.Entities;

namespace ECommerce.TestShoppingCart.Builders
{
    public class ProductBuilder
    {
        private byte[]? _image = { 0x32, 0x00, 0x1E, 0x00 };
        private string _name = new Faker().Commerce.ProductName();
        private string _description = new Faker().Commerce.ProductDescription();
        private string? _otherDetails = "Others details";
        private int _quantity = 1;
        private decimal _price = decimal.Parse(new Faker().Commerce.Price(100.55m, 9800.71m, 2));

        public static ProductBuilder NewObject()
        {
            return new ProductBuilder();
        }

        public Product DomainBuilder()
        {
            return new Product
            {
                Id = 1,
                Name = _name,
                Description = _description,
                OtherDetails = _otherDetails,
                Amount = _quantity,
                Price = _price,
                Image = _image
            };
        }

        public ProductSaveRequest SaveRequestBuilder()
        {
            return new ProductSaveRequest
            {
                Description = _description,
                Image = _image,
                Name = _name,
                OtherDetails = _otherDetails,
                Price = _price,
                Amount = _quantity
            };
        }

        public ProductResponse ResponseBuilder()
        {
            return new ProductResponse
            {
                Id = 1,
                Description = _description,
                Image = _image,
                Name = _name,
                OtherDetails = _otherDetails,
                Price = _price,
                Quantity = _quantity
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
        
        public ProductBuilder WithOthersDetails(string othersDetails)
        {
            _otherDetails = othersDetails;
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
