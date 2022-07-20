using ECommerce.ShoppingCartServiceAPI.Domain.Entities;

namespace ECommerce.ShoppingCartServiceAPI.Domain.Interface.RepositoryContract;

public interface IShoppingCartRepository
{
    Task SetAsync(ShoppingCart shoppingCart);
    Task<ShoppingCart> GetAsync(string key);
    Task RemoveAsync(string key);
    Task RefreshAsync(string key);
}
