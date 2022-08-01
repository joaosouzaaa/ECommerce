using ECommerce.ProductServiceAPI.Data.ORM.Context;
using ECommerce.ProductServiceAPI.Domain.Entities;
using ECommerce.ProductServiceAPI.Domain.Handlers.Pagination;
using ECommerce.ProductServiceAPI.Domain.Interface;
using ECommerce.ProductServiceAPI.Domain.Interface.RepositoryContract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace ECommerce.ProductServiceAPI.Data.Repository;

public class ProductTypeRepository : IProductTypeRepository
{
    protected readonly ProductMySqlContext _context;
    private readonly IPagingService<ProductType> _pagingService;
    private DbSet<ProductType> _dbSet => _context.Set<ProductType>();

    public ProductTypeRepository(ProductMySqlContext context, IPagingService<ProductType> pagingService)
    {
        _context = context;
        _pagingService = pagingService;
    }

    public async Task<ProductType> FindByAsync(int id, Func<IQueryable<ProductType>, IIncludableQueryable<ProductType, object>> include = null, bool asNoTracking = false) =>
        await IncludeMultiple((IQueryable<ProductType>)_dbSet, include, asNoTracking).SingleOrDefaultAsync(pt => pt.Id == id);


    public async Task<PageList<ProductType>> FindWithEntitiesPaging(PageParams pageParams, Func<IQueryable<ProductType>, IIncludableQueryable<ProductType, object>> include = null, bool asNoTracking = false)
    {
        var query = IncludeMultiple((IQueryable<ProductType>)_dbSet, include, asNoTracking);

        return await _pagingService.CreatePaginationAsync(query, pageParams.PageNumber, pageParams.PageSize);
    }

    private IQueryable<ProductType> IncludeMultiple(IQueryable<ProductType> query, Func<IQueryable<ProductType>, IIncludableQueryable<ProductType, object>> include = null, bool asNoTracking = false)
    {

        if (asNoTracking)
            query.AsNoTracking();

        if (include != null)
            query = include(query);

        return query;
    }

    public void Dispose() => _context.Dispose();

    private async Task<bool> SaveDbAsync() => (await _context.SaveChangesAsync()) > 0;

    public async Task<bool> HaveObjectInDbAsync(Expression<Func<ProductType, bool>> where) =>
        await _dbSet.AsNoTracking().AnyAsync(where);
    

    public async Task<bool> SaveAsync(ProductType entity)
    {
        await _dbSet.AddAsync(entity);

        return await SaveDbAsync();
    }

    public async Task<bool> UpdateAsync(ProductType entity)
    {
        _context.Entry(entity).State = EntityState.Modified;

        return await SaveDbAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (_context.Entry(entity).State == EntityState.Detached)
            _dbSet.Attach(entity);

        _dbSet.Remove(entity);
        return await SaveDbAsync();
    }
}
