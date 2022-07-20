using ECommerce.ShoppingCartServiceAPI.ApplicationService.Interfaces.ShoppingCart;
using ECommerce.ShoppingCartServiceAPI.ApplicationService.Request;
using ECommerce.ShoppingCartServiceAPI.ApplicationService.Response;
using ECommerce.ShoppingCartServiceAPI.ApplicationService.Service.Base;
using ECommerce.ShoppingCartServiceAPI.Domain.Entities;
using ECommerce.ShoppingCartServiceAPI.Domain.Extensions;
using ECommerce.ShoppingCartServiceAPI.Domain.Interface;
using ECommerce.ShoppingCartServiceAPI.Domain.Interface.RepositoryContract;

namespace ECommerce.ShoppingCartServiceAPI.ApplicationService.Service;

public class ShoppingCartService : BaseService<ShoppingCart>, IShoppingCartService
{
    private readonly IShoppingCartRepository _shoppingCartRepository;

    public ShoppingCartService(IShoppingCartRepository shoppingCartRepository,
                               IValidate<ShoppingCart> validate, INotificationHandler notification)
                               : base(validate, notification)
    {
        _shoppingCartRepository = shoppingCartRepository;
    }

    public async Task<bool> SetAsync(ShoppingCartSaveRequest saveRequest)
    {
        var shoppingCart = saveRequest.MapTo<ShoppingCartSaveRequest, ShoppingCart>();

        if (!await ValidationAsync(shoppingCart))
            return false;
        else
        {
            await _shoppingCartRepository.SetAsync(shoppingCart);
            return true;
        }
    }

    public async Task<ShoppingCartResponse> GetAsync(string key)
    {
        var shoppingCart = await _shoppingCartRepository.GetAsync(key);
        
        if (shoppingCart != null)
            return shoppingCart.MapTo<ShoppingCart, ShoppingCartResponse>();

        return null;
    }

    public async Task RemoveAsync(string key) => await _shoppingCartRepository.RemoveAsync(key);

    public async Task RefreshAsync(string key) => await _shoppingCartRepository.RefreshAsync(key);
}
