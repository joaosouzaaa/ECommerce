using ECommerce.ShoppingCartServiceAPI.ApplicationService.Service.Base;
using ECommerce.ShoppingCartServiceAPI.Domain.Entities;
using ECommerce.ShoppingCartServiceAPI.Domain.Interface;

namespace ECommerce.ShoppingCartServiceAPI.ApplicationService.Service;

public class ShoppingCartService : BaseService<ShoppingCart>
{
    public ShoppingCartService(IValidate<ShoppingCart> validate, INotificationHandler notification)
        : base(validate, notification)
    {

    }
}
