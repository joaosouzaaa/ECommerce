using ECommerce.ShoppingCartServiceAPI.Data.ORM.Context;
using ECommerce.ShoppingCartServiceAPI.Data.Repository.RepositoryBase;
using ECommerce.ShoppingCartServiceAPI.Domain.Entities;
using ECommerce.ShoppingCartServiceAPI.Domain.Interface;
using ECommerce.ShoppingCartServiceAPI.Domain.Interface.RepositoryContract;

namespace ECommerce.ShoppingCartServiceAPI.Data.Repository;

public class ProductRepository : BaseQueryCommandsRepository<Product>, IProductRepository
{
    public ProductRepository(ShoppingCartContext context, IPagingService<Product> pagingService)
        : base(context, pagingService)
    {
    }
}
