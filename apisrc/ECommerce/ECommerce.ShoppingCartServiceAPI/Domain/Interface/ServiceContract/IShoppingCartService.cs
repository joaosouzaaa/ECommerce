using ECommerce.ShoppingCartServiceAPI.ApplicationService.Request;
using ECommerce.ShoppingCartServiceAPI.ApplicationService.Response;

namespace ECommerce.ShoppingCartServiceAPI.Domain.Interface.ServiceContract
{
    public interface IShoppingCartService
    {
        Task<ShoppingCartResponse> GetShoppingCartAsync(int shoppingCartId);
        Task<bool> FinalizePurchase(FinalizePurchaseRequest finalizePurchaseRequest);
        Task<bool> AddProductAsync(int shoppingCartId, ProductSaveRequest saveProduct);
        Task<bool> AddCoupoum(int shoppingCartId, string CouponCode);
        Task<bool> RemoveProductAsync(int shoppingCartId, ProductSaveRequest removeProduct);
    }
}
