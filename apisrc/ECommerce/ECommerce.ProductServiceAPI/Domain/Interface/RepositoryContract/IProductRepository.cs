using ECommerce.ProductServiceAPI.Domain.Entities;
using ECommerce.ProductServiceAPI.Domain.Handlers.Pagination;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace ECommerce.ProductServiceAPI.Domain.Interface.RepositoryContract;

public interface IProductRepository : IDisposable
{
    Task<bool> SaveAsync(Product entity);
    Task<bool> UpdateAsync(Product entity);
    Task<bool> DeleteAsync(int id);
    Task<bool> HaveObjectInDbAsync(Expression<Func<Product, bool>> where);

    Task<Product> FindByAsync(int id, Func<IQueryable<Product>, IIncludableQueryable<Product, object>> include = null, bool asNoTracking = false);
    Task<PageList<Product>> FindWithEntitiesPaging(PageParams pageParams, Func<IQueryable<Product>, IIncludableQueryable<Product, object>> include = null, bool asNoTracking = false);
}
