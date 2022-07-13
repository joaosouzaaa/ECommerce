using ECommerce.ShoppingCartServiceAPI.Data.ORM.Context;
using ECommerce.ShoppingCartServiceAPI.Domain.Entities;
using ECommerce.ShoppingCartServiceAPI.Domain.Interface;
using ECommerce.ShoppingCartServiceAPI.Domain.Interface.RepositoryContract;

namespace ECommerce.ShoppingCartServiceAPI.Data.Repository;

public class ProductRepository : BaseQueryCommandsRepository<Product>, IProductRepository
{
    public ProductRepository(ShoppingCartSqlServerContext context, IPagingService<Product> pagingService)
        : base(context, pagingService)
    {
    }
}
