using ECommerce.ProductServiceAPI.ApplicationService.DTOs.Request.ProductRequest;
using ECommerce.ProductServiceAPI.ApplicationService.DTOs.Response.ProductResponse;
using ECommerce.ProductServiceAPI.ApplicationService.Services.Interfaces;
using ECommerce.ProductServiceAPI.Domain.Entities;
using ECommerce.ProductServiceAPI.Domain.Enum;
using ECommerce.ProductServiceAPI.Domain.Extensions;
using ECommerce.ProductServiceAPI.Domain.Interface;
using ECommerce.ProductServiceAPI.Domain.Interface.RepositoryContract;

namespace ECommerce.ProductServiceAPI.ApplicationService.Services
{
    public class ProductService : BaseService<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IValidate<Product> validate, INotificationHandler notification, IProductRepository productRepository) 
            : base(validate, notification)
        {
            this._productRepository = productRepository;
        }

        public async Task<ProductSearchResponse> FindBy(int id)
        {
            if (!await _productRepository.HaveObjectInDbAsync(p => p.Id == id))
                _notification.AddNotification("Id", EMessage.NotFound.Description().FormatTo("Product"));

            var response = await _productRepository.FindByAsync(id);

            return response.MapTo<Product, ProductSearchResponse>();
        }

        public async Task<bool> SaveAsync(ProductSaveRequest saveRequest)
        {
            var product = saveRequest.MapTo<ProductSaveRequest, Product>();

            if (!await ValidationAsync(product))
                return false;
            else
                return await _productRepository.SaveRepositoryAsync(product);
        }

        public Task<bool> UpdateAsync(ProductUpdateRequest updateRequest)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

    }
}
