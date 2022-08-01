using ECommerce.ProductServiceAPI.ApplicationService.DTOs.Request.ProductRequest;
using ECommerce.ProductServiceAPI.ApplicationService.DTOs.Response.ProductResponse;
using ECommerce.ProductServiceAPI.Domain.Handlers.Pagination;

namespace ECommerce.ProductServiceAPI.Domain.Interface.ServiceContract
{
    public interface IProductService : IDisposable
    {
        Task<bool> SaveAsync(ProductSaveRequest saveRequest);
        Task<bool> UpdateAsync(ProductUpdateRequest updateRequest);
        Task<bool> DeleteAsync(int id);
        Task<ProductSearchResponse> FindByAsync(int id);
        Task<PageList<ProductSearchResponse>> FindByWithPagination(PageParams pageParams);
    }
}
