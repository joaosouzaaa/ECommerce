using ECommerce.ShoppingCartServiceAPI.ApplicationService.Service.Base;
using ECommerce.ShoppingCartServiceAPI.Domain.Entities;
using ECommerce.ShoppingCartServiceAPI.Domain.Interface;
using ECommerce.ShoppingCartServiceAPI.Domain.Interface.RepositoryContract;

namespace ECommerce.ShoppingCartServiceAPI.ApplicationService.Service;

public class CartShoppingService : BaseService<ShoppingCartHeader>
{
    private readonly IShoppingCartRepository _shoppingCartRepository;

    public CartShoppingService(IValidate<ShoppingCartHeader> validate, 
                               INotificationHandler notification,
                               IShoppingCartRepository shoppingCartRepository) 
        : base(validate, notification)
    {
        _shoppingCartRepository = shoppingCartRepository;
    }
}
