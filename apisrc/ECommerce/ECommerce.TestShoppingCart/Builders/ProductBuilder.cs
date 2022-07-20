using Bogus;
using ECommerce.ShoppingCartServiceAPI.Domain.Entities;

namespace ECommerce.TestShoppingCart.Builders
{
    public class ProductBuilder
    {
        private byte[]? _image;
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
                Name = this._name,
                Description = this._description,
                OtherDetails = this._otherDetails,
                Quantity = this._quantity,
                Price = this._price
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

        public ProductBuilder WithQuanity(int quantity)
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
