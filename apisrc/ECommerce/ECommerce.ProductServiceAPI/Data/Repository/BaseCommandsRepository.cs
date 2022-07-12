using ECommerce.ProductServiceAPI.Data.ORM.Context;
using ECommerce.ProductServiceAPI.Domain.Interface.RepositoryContract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ECommerce.ProductServiceAPI.Data.Repository;

public class BaseCommandsRepository<TEntity> : IBaseCommandsRepository<int, TEntity>
    where TEntity : class
{
    protected readonly ProductMySqlContext _context;
    protected DbSet<TEntity> _dbSet => _context.Set<TEntity>();

    public BaseCommandsRepository(ProductMySqlContext context)
    {
        _context = context;
    }

    private async Task<bool> SaveDbAsync() => (await _context.SaveChangesAsync()) > 0;

    public Task<bool> HaveObjectInDb(Expression<Func<TEntity, bool>> where) => _dbSet.AsNoTracking().AnyAsync(where);

    public async Task<bool> SaveAsync(TEntity entity)
    {
        _dbSet.Add(entity);
        _context.Entry(entity).State = EntityState.Added;
        return await SaveDbAsync();
    }

    public async Task<bool> UpdateAsync(TEntity entity)
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
}
