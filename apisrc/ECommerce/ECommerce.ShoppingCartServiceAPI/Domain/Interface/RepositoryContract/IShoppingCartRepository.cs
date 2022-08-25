using ECommerce.ShoppingCartServiceAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;

namespace ECommerce.ShoppingCartServiceAPI.Domain.Interface.RepositoryContract;

public interface IShoppingCartRepository : IDisposable
{
    Task<bool> SaveAsync(ShoppingCartHeader entity);
    Task<bool> UpdateAsync(ShoppingCartHeader entity);
    Task<ShoppingCartHeader> FindByAsync(int id, Func<IQueryable<ShoppingCartHeader>, IIncludableQueryable<ShoppingCartHeader, object>> include = null, bool asNotracking = false);
}
