using Bogus;
using ECommerce.ProductServiceAPI.Domain.Entities;
using ECommerce.ProductServiceAPI.Domain.Enum;

namespace ECommerce.TestProductService.Builders
{
    public class ProductTypeBuilder
    {
        private string _name = new Faker().Commerce.Product();
        private ECategory _category = new Faker().PickRandom<ECategory>();
        private List<Product> _products;

        public static ProductTypeBuilder NewObject()
        {
            return new ProductTypeBuilder();
        }

        public ProductType DomainBuilder()
        {
            return new ProductType
            {
                Name = _name,
                Category = _category,
                Products = new List<Product>(),
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now
            };
        }

        public ProductTypeBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public ProductTypeBuilder WithCategory(ECategory category)
        {
            _category = category;
            return this;
        }
    }
}
