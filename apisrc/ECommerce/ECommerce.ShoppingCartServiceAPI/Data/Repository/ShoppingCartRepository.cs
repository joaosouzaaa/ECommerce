using ECommerce.ShoppingCartServiceAPI.Data.ORM.Context;
using ECommerce.ShoppingCartServiceAPI.Domain.Entities;
using ECommerce.ShoppingCartServiceAPI.Domain.Interface;
using ECommerce.ShoppingCartServiceAPI.Domain.Interface.RepositoryContract;

namespace ECommerce.ShoppingCartServiceAPI.Data.Repository;

public class ShoppingCartRepository : BaseQueryCommandsRepository<ShoppingCart>, IShoppingCartRepository
{
    public ShoppingCartRepository(ShoppingCartSqlServerContext context, IPagingService<ShoppingCart> pagingService)
        : base(context, pagingService)
    {
    }
}
