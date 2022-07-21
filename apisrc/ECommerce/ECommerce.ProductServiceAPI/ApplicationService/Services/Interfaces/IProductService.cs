using ECommerce.ProductServiceAPI.ApplicationService.DTOs.Request.ProductRequest;
using ECommerce.ProductServiceAPI.ApplicationService.DTOs.Response.ProductResponse;

namespace ECommerce.ProductServiceAPI.ApplicationService.Services.Interfaces
{
    public interface IProductService
    {
        Task<bool> SaveAsync(ProductSaveRequest saveRequest);
        Task<bool> UpdateAsync(ProductUpdateRequest updateRequest);
        Task DeleteAsync(int id);
        Task<ProductSearchResponse> FindBy(int id);
    }
}
