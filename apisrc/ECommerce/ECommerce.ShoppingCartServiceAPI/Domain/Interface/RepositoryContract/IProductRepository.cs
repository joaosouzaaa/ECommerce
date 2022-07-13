using ECommerce.ShoppingCartServiceAPI.Domain.Entities;

namespace ECommerce.ShoppingCartServiceAPI.Domain.Interface.RepositoryContract;

public interface IProductRepository : IBaseCommandsRepository<int, Product>,
    IBaseQueryCommandsRepository<int, Product>
{
}
