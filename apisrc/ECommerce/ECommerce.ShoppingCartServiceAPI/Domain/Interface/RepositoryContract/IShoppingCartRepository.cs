using ECommerce.ShoppingCartServiceAPI.Domain.Entities;

namespace ECommerce.ShoppingCartServiceAPI.Domain.Interface.RepositoryContract;

public interface IShoppingCartRepository : IBaseQueryCommandsRepository<int, ShoppingCart>
{

}
