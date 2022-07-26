using ECommerce.ShoppingCartServiceAPI.ApplicationService.Request;
using ECommerce.ShoppingCartServiceAPI.ApplicationService.Response;

namespace ECommerce.ShoppingCartServiceAPI.ApplicationService.Interfaces.ShoppingCart
{
    public interface IShoppingCartService
    {
        Task<bool> SetAsync(ShoppingCartSaveRequest saveRequest);
        Task<ShoppingCartResponse> GetAsync(string key);
        Task<bool> RemoveAsync(string key);
        Task<bool> RefreshAsync(string key);
    }
}
