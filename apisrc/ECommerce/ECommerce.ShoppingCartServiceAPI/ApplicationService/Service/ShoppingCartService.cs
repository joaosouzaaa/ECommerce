using ECommerce.ShoppingCartServiceAPI.ApplicationService.Interfaces.ShoppingCart;
using ECommerce.ShoppingCartServiceAPI.ApplicationService.Request;
using ECommerce.ShoppingCartServiceAPI.ApplicationService.Response;
using ECommerce.ShoppingCartServiceAPI.ApplicationService.Service.Base;
using ECommerce.ShoppingCartServiceAPI.Domain.Entities;
using ECommerce.ShoppingCartServiceAPI.Domain.Enum;
using ECommerce.ShoppingCartServiceAPI.Domain.Extensions;
using ECommerce.ShoppingCartServiceAPI.Domain.Handlers.Notification;
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
        shoppingCart.TotalItens = saveRequest.ProductsSaveRequest.Count;
        shoppingCart.TotalPrice = 0;
        foreach (var product in saveRequest.ProductsSaveRequest)
            shoppingCart.TotalPrice += product.Price;

        if (!await ValidationAsync(shoppingCart))
            return false;
        
        await _shoppingCartRepository.SetAsync(shoppingCart);

        return true;
    }

    public async Task<ShoppingCartResponse> GetAsync(string key)
    {
        var shoppingCart = await _shoppingCartRepository.GetAsync(key);

        if (shoppingCart != null)
            return shoppingCart.MapTo<ShoppingCart, ShoppingCartResponse>();

        return null;
    }

    public async Task<bool> RemoveAsync(string key)
    {
        var getString = await _shoppingCartRepository.GetStringAsync(key);
        if (getString != null)
        {
            await _shoppingCartRepository.RemoveAsync(key);
            return true;
        }

        return _notification.AddNotification(new DomainNotification("ShoppingCart", EMessage.NotFound.Description().FormatTo("Shopping Cart")));
    }

    public async Task<bool> RefreshAsync(string key)
    {
        var getString = await _shoppingCartRepository.GetStringAsync(key);
        if (getString != null)
        {
            await _shoppingCartRepository.RefreshAsync(key);
            return true;
        }

        return _notification.AddNotification(new DomainNotification("ShoppingCart", EMessage.NotFound.Description().FormatTo("Shopping Cart")));
    }
}
