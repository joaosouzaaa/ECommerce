using ECommerce.ProductServiceAPI.Domain.Entities;
using ECommerce.ProductServiceAPI.Domain.Handlers.Pagination;
using System.Linq.Expressions;

namespace ECommerce.ProductServiceAPI.Domain.Interface.RepositoryContract;

public interface IProductRepository : IDisposable
{
    Task<bool> SaveAsync(Product entity);
    Task<bool> UpdateAsync(Product entity);
    Task<bool> DeleteAsync(int id);
    Task<bool> HaveObjectInDb(Expression<Func<Product, bool>> where);

    Task<Product> FindByAsync(int id, bool asNoTracking = false, params Expression<Func<Product, object>>[] includes);
    Task<PageList<Product>> FindWithEntitiesPaging(PageParams pageParams, bool asNoTracking = false, params Expression<Func<Product, object>>[] includes);
}
