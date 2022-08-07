using ECommerce.ProductServiceAPI.ApplicationService.DTOs.Request.ProductTypeRequest;
using ECommerce.ProductServiceAPI.ApplicationService.DTOs.Response.ProductTypeResponse;
using ECommerce.ProductServiceAPI.Domain.Entities;
using ECommerce.ProductServiceAPI.Domain.Enum;
using ECommerce.ProductServiceAPI.Domain.Extensions;
using ECommerce.ProductServiceAPI.Domain.Handlers.Notification;
using ECommerce.ProductServiceAPI.Domain.Handlers.Pagination;
using ECommerce.ProductServiceAPI.Domain.Interface;
using ECommerce.ProductServiceAPI.Domain.Interface.RepositoryContract;
using ECommerce.ProductServiceAPI.Domain.Interface.ServiceContract;
using ECommerce.ProductServiceAPI.RabbitMQSender;

namespace ECommerce.ProductServiceAPI.ApplicationService.Services;

public class ProductTypeService : BaseService<ProductType>,IProductTypeService
{
    private readonly IProductTypeRepository _productTypeRepository;
    private readonly IRabbitMQMessageSender _rabbitMQ;
    private const string _queue = "RegisterProductTypeQueue";

    public ProductTypeService(IValidate<ProductType> validate, 
                              INotificationHandler notification,
                              IProductTypeRepository productTypeRepository,
                              IRabbitMQMessageSender rabbitMQ)
        : base(validate, notification)
    {
        _productTypeRepository = productTypeRepository;
        _rabbitMQ = rabbitMQ;
    }

    public void Dispose() => _productTypeRepository.Dispose();

    public async Task<ProductTypeSearchResponse> FindByAsync(int id)
    {
        var productType = await _productTypeRepository.FindByAsync(id);

        return productType.MapTo<ProductType, ProductTypeSearchResponse>();
    }

    public async Task<PageList<ProductTypeSearchResponse>> FindByWithPagination(PageParams pageParams)
    {
        var procutsType = await _productTypeRepository.FindWithEntitiesPaging(pageParams);

        return procutsType.MapTo<PageList<ProductType>, PageList<ProductTypeSearchResponse>>();
    }

    public async Task<bool> SaveAsync(ProductTypeSaveRequest saveRequest)
    {
        if (await _productTypeRepository.HaveObjectInDbAsync(pt => pt.Name == saveRequest.Name))
            return _notification.AddNotification(new DomainNotification("Exist", EMessage.Exist.Description().FormatTo($"{saveRequest.Name}")));

        var productType = saveRequest.MapTo<ProductTypeSaveRequest, ProductType>();
        if (!await ValidationAsync(productType) || _notification.HasNotification())
            return false;

        _rabbitMQ.SendMessage(saveRequest, _queue);
        return await _productTypeRepository.SaveAsync(productType);

    }

    public async Task<bool> UpdateAsync(ProductTypeUpdateRequest updateRequest)
    {
        var productType = await _productTypeRepository.FindByAsync(updateRequest.ProductTypeId);
        if (productType == null)
            return _notification.AddNotification(new DomainNotification("not found", EMessage.NotFound.Description().FormatTo("Product type")));

        productType = updateRequest.MapTo<ProductTypeUpdateRequest, ProductType>();
        if (!await ValidationAsync(productType) || _notification.HasNotification())
            return false;

        _rabbitMQ.SendMessage(updateRequest, _queue);
        return await _productTypeRepository.UpdateAsync(productType);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        if (!await _productTypeRepository.HaveObjectInDbAsync(pt => pt.Id == id))
            return _notification.AddNotification(new DomainNotification("not found", EMessage.NotFound.Description().FormatTo("Product type")));
            
        return await _productTypeRepository.DeleteAsync(id);
    }

}
