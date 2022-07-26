using ECommerce.ShoppingCartServiceAPI.Domain.Entities;
using ECommerce.ShoppingCartServiceAPI.Domain.Interface.RepositoryContract;
using Microsoft.Extensions.Caching.Distributed;
using System.Text;
using System.Text.Json;

namespace ECommerce.ShoppingCartServiceAPI.Data.Repository;

public class ShoppingCartRepository : IShoppingCartRepository
{
    private readonly IDistributedCache _cache;

    public ShoppingCartRepository(IDistributedCache cache)
    {
        _cache = cache;
    }


    public async Task SetAsync(ShoppingCart shoppingCart)
    {
        var key = shoppingCart.Id;
        var jsonData = JsonSerializer.Serialize(shoppingCart);
        var dataInByteArray = Encoding.UTF8.GetBytes(jsonData);

        await _cache.SetAsync(key, dataInByteArray);
    }

    public async Task<ShoppingCart> GetAsync(string key)
    {
        var cachedData = await _cache.GetAsync(key);

        if (cachedData != null)
        {
            var shoppingCart = new ShoppingCart();
            var cachedDataString = Encoding.UTF8.GetString(cachedData);
            shoppingCart = JsonSerializer.Deserialize<ShoppingCart>(cachedDataString);

            return shoppingCart;
        }

        return null;
    }

    public async Task RemoveAsync(string key) =>
        await _cache.RemoveAsync(key);

    public async Task RefreshAsync(string key) =>
        await _cache.RefreshAsync(key);

    public async Task<string> GetStringAsync(string key) =>
        await _cache.GetStringAsync(key);
}
