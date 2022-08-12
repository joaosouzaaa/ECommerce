using ECommerce.ProductServiceAPI.Data.ORM.Context;
using ECommerce.ProductServiceAPI.Domain.Entities;
using ECommerce.ProductServiceAPI.Domain.Handlers.Pagination;
using ECommerce.ProductServiceAPI.Domain.Interface;
using ECommerce.ProductServiceAPI.Domain.Interface.RepositoryContract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace ECommerce.ProductServiceAPI.Data.Repository;

public class ProductRepository : IProductRepository
{
    protected readonly ProductMySqlContext _context;
    private readonly IPagingService<Product> _pagingService;
    protected DbSet<Product> _dbSet => _context.Set<Product>();
    public ProductRepository(ProductMySqlContext context, IPagingService<Product> pagingService)
    {
        _context = context;
        _pagingService = pagingService;
    }

    public async Task<Product> FindByAsync(int id, Func<IQueryable<Product>, IIncludableQueryable<Product, object>> include = null, bool asNoTracking = false) =>
        await IncludeMultiple().SingleOrDefaultAsync(p => p.Id == id);

    public async Task<PageList<Product>> FindWithEntitiesPaging(PageParams pageParams, Func<IQueryable<Product>, IIncludableQueryable<Product, object>> include = null, bool asNoTracking = false)
    {
        var query = IncludeMultiple(include, asNoTracking);

        return await _pagingService.CreatePaginationAsync(query, pageParams.PageNumber, pageParams.PageSize);
    }

    public Task<bool> HaveObjectInDbAsync(Expression<Func<Product, bool>> where) => _dbSet.AsNoTracking().AnyAsync(where);

    public void Dispose() => _context.Dispose();

    private async Task<bool> SaveDbAsync() => (await _context.SaveChangesAsync()) > 0;

    public async Task<bool> SaveAsync(Product entity)
    {
        await _dbSet.AddAsync(entity);
        return await SaveDbAsync();
    }

    public async Task<bool> UpdateAsync(Product entity)
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

    private IQueryable<Product> IncludeMultiple(Func<IQueryable<Product>, IIncludableQueryable<Product, object>> include = null, bool asNoTracking = false)
    {
        var query = (IQueryable<Product>)_dbSet;

        if (asNoTracking)
            query = _dbSet.AsNoTracking();

        if (include != null)
            query = include(query);

        return query;
    }
}
