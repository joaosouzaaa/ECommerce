using ECommerce.ProductServiceAPI.Data.ORM.Context;
using ECommerce.ProductServiceAPI.Domain.Entities;
using ECommerce.ProductServiceAPI.Domain.Handlers.Pagination;
using ECommerce.ProductServiceAPI.Domain.Interface;
using ECommerce.ProductServiceAPI.Domain.Interface.RepositoryContract;
using Microsoft.EntityFrameworkCore;
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

    public async Task<Product> FindByAsync(int id, bool asNoTracking = false, params Expression<Func<Product, object>>[] includes) =>
    await IncludeMultiple(_dbSet, asNoTracking, includes).FirstOrDefaultAsync(e => e.Id == id);


    public async Task<PageList<Product>> FindWithEntitiesPaging(PageParams pageParams, bool asNoTracking = false, params Expression<Func<Product, object>>[] includes)
    {
        var query = IncludeMultiple(_dbSet, asNoTracking, includes);

        return await _pagingService.CreatePaginationAsync(query, pageParams.PageNumber, pageParams.PageSize);
    }

    private IQueryable<Product> IncludeMultiple(IQueryable<Product> query, bool asNoTrack, params Expression<Func<Product, object>>[] includes)
    {
        query = includes.Aggregate(query, (current, include) => current.Include(include));

        if (asNoTrack) query = query.AsNoTracking();

        return query;
    }

    private async Task<bool> SaveDbAsync() => (await _context.SaveChangesAsync()) > 0;

    public Task<bool> HaveObjectInDb(Expression<Func<Product, bool>> where) => _dbSet.AsNoTracking().AnyAsync(where);

    public async Task<bool> SaveAsync(Product entity)
    {
        _dbSet.Add(entity);
        _context.Entry(entity).State = EntityState.Added;
        return await SaveDbAsync();
    }

    public async Task<bool> UpdateAsync(Product entity)
    {
        _dbSet.Update(entity);
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

    public void Dispose() => _context.Dispose();
   
}
