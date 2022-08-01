using ECommerce.ProductServiceAPI.Domain.Entities;
using ECommerce.ProductServiceAPI.Domain.Handlers.Pagination;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace ECommerce.ProductServiceAPI.Domain.Interface.RepositoryContract;

public interface IProductTypeRepository : IDisposable
{
    Task<bool> SaveAsync(ProductType entity);
    Task<bool> UpdateAsync(ProductType entity);
    Task<bool> DeleteAsync(int id);
    Task<bool> HaveObjectInDbAsync(Expression<Func<ProductType, bool>> where);

    Task<ProductType> FindByAsync(int id, Func<IQueryable<ProductType>, IIncludableQueryable<ProductType, object>> include = null, bool asNoTracking = false);
    Task<PageList<ProductType>> FindWithEntitiesPaging(PageParams pageParams, Func<IQueryable<ProductType>, IIncludableQueryable<ProductType, object>> include = null, bool asNoTracking = false);
}
