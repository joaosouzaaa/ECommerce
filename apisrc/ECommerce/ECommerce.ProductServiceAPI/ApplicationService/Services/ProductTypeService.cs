using ECommerce.ProductServiceAPI.ApplicationService.DTOs.Request.ProductTypeRequest;
using ECommerce.ProductServiceAPI.ApplicationService.DTOs.Response.ProductTypeResponse;
using ECommerce.ProductServiceAPI.Domain.Handlers.Pagination;
using ECommerce.ProductServiceAPI.Domain.Interface.ServiceContract;

namespace ECommerce.ProductServiceAPI.ApplicationService.Services;

public class ProductTypeService : IProductTypeService
{


    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public Task<ProductTypeSearchResponse> FindByAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<PageList<ProductTypeSearchResponse>> FindByWithPagination(PageParams pageParams)
    {
        throw new NotImplementedException();
    }

    public Task<bool> SaveAsync(ProductTypeSaveRequest saveRequest)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(ProductTypeUpdateRequest updateRequest)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

}
