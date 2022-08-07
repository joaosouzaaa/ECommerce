using Bogus;
using ECommerce.ProductServiceAPI.ApplicationService.DTOs.Request.ProductTypeRequest;
using ECommerce.ProductServiceAPI.ApplicationService.DTOs.Response.ProductTypeResponse;
using ECommerce.ProductServiceAPI.Domain.Entities;
using ECommerce.ProductServiceAPI.Domain.Enum;

namespace ECommerce.TestProductService.Builders
{
    public class ProductTypeBuilder
    {
        private int _id = new Faker().Random.Int(1, 100);
        private string _name = new Faker().Commerce.Product();
        private ECategory _category = new Faker().PickRandom<ECategory>();

        public static ProductTypeBuilder NewObject()
        {
            return new ProductTypeBuilder();
        }

        public ProductType DomainBuild()
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

        public ProductTypeSaveRequest DtoSaveBuild()
        {
            return new ProductTypeSaveRequest
            {
                
                Name = _name,
                Category = _category
            };
        }

        public ProductTypeUpdateRequest DtoUpdateBuild()
        {
            return new ProductTypeUpdateRequest
            {
                ProductTypeId = _id,
                Name = _name,
                Category = _category
            };
        }

        public ProductTypeSearchResponse DtoSearchResponseBuild()
        {
            return new ProductTypeSearchResponse
            {
                ProductTypeId = _id,
                Name = _name,
                Category = _category
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
