using ECommerce.ProductServiceAPI.ApplicationService.DTOs.Request.ProductTypeRequest;
using ECommerce.ProductServiceAPI.ApplicationService.DTOs.Response.ProductTypeResponse;
using ECommerce.ProductServiceAPI.Domain.Handlers.Pagination;

namespace ECommerce.ProductServiceAPI.Domain.Interface.ServiceContract;

public interface IProductTypeService : IDisposable
{
    Task<bool> SaveAsync(ProductTypeSaveRequest saveRequest);
    Task<bool> UpdateAsync(ProductTypeUpdateRequest updateRequest);
    Task<bool> DeleteAsync(int id);
    Task<ProductTypeSearchResponse> FindByAsync(int id);
    Task<PageList<ProductTypeSearchResponse>> FindByWithPagination(PageParams pageParams);
}
