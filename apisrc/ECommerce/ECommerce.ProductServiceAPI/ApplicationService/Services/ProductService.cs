using ECommerce.ProductServiceAPI.ApplicationService.DTOs.Request.ProductRequest;
using ECommerce.ProductServiceAPI.ApplicationService.DTOs.Response.ProductResponse;
using ECommerce.ProductServiceAPI.Domain.Entities;
using ECommerce.ProductServiceAPI.Domain.Enum;
using ECommerce.ProductServiceAPI.Domain.Extensions;
using ECommerce.ProductServiceAPI.Domain.Handlers.Notification;
using ECommerce.ProductServiceAPI.Domain.Handlers.Pagination;
using ECommerce.ProductServiceAPI.Domain.Interface;
using ECommerce.ProductServiceAPI.Domain.Interface.RepositoryContract;
using ECommerce.ProductServiceAPI.Domain.Interface.ServiceContract;
using ECommerce.ProductServiceAPI.RabbitMQSender;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.ProductServiceAPI.ApplicationService.Services
{
    public class ProductService : BaseService<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IRabbitMQMessageSender _rabbitMQ;
        private const string _queue = "RegisterProductQueue";

        public ProductService(IValidate<Product> validate, 
                              INotificationHandler notification,
                              IProductRepository productRepository,
                              IRabbitMQMessageSender rabbitMQ) 
            : base(validate, notification)
        {
            this._productRepository = productRepository;
            this._rabbitMQ = rabbitMQ;
        }

        public void Dispose() => _productRepository.Dispose();

        public async Task<ProductSearchResponse> FindByAsync(int id)
        {
            var product = await _productRepository.FindByAsync(id,  p => p.Include(p => p.ProductType), false);
                
            return product.MapTo<Product, ProductSearchResponse>();
        }

        public async Task<PageList<ProductSearchResponse>> FindByWithPagination(PageParams pageParams)
        {
            var products = await _productRepository.FindWithEntitiesPaging(pageParams, p => p.Include(p => p.ProductType));

            return products.MapTo<PageList<Product>, PageList<ProductSearchResponse>>();
        }

        public async Task<bool> SaveAsync(ProductSaveRequest saveRequest)
        {
            if (await _productRepository.HaveObjectInDbAsync(p => p.Name == saveRequest.Name))
                return _notification.AddNotification(new DomainNotification("Exist", EMessage.Exist.Description().FormatTo($"{saveRequest.Name}")));

            var product = saveRequest.MapTo<ProductSaveRequest, Product>();

            if (!await ValidationAsync(product))
                return false;

            _rabbitMQ.SendMessage(saveRequest, _queue);
            return await _productRepository.SaveAsync(product);
        }

        public async Task<bool> UpdateAsync(ProductUpdateRequest updateRequest)
        {
            var product = await _productRepository.FindByAsync(updateRequest.ProductId);
            if (product == null)
                return _notification.AddNotification(new DomainNotification("not found", EMessage.NotFound.Description().FormatTo("Produto")));

            product = updateRequest.MapTo<ProductUpdateRequest, Product>();

            if (!await ValidationAsync(product))
                return false;

            _rabbitMQ.SendMessage(updateRequest, _queue);
            return await _productRepository.UpdateAsync(product);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            if (!await _productRepository.HaveObjectInDbAsync(p => p.Id == id))
                return _notification.AddNotification(new DomainNotification("not found", EMessage.NotFound.Description().FormatTo("Produto")));

            return await _productRepository.DeleteAsync(id);
        } 
    }
}
