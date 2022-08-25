using ECommerce.ShoppingCartServiceAPI.Data.ORM.Context;
using ECommerce.ShoppingCartServiceAPI.Domain.Entities;
using ECommerce.ShoppingCartServiceAPI.Domain.Interface.RepositoryContract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace ECommerce.ShoppingCartServiceAPI.Data.Repository;

public class ShoppingCartRepository : IShoppingCartRepository
{
    private readonly ShoppingCartContext _context;
    private DbSet<ShoppingCartHeader> _dbSet => _context.Set<ShoppingCartHeader>();

    public ShoppingCartRepository(ShoppingCartContext context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();

    private async Task<bool> CommitInDbAsync() => await _context.SaveChangesAsync() > 0;

    public async Task<ShoppingCartHeader> FindByAsync(int id, Func<IQueryable<ShoppingCartHeader>, IIncludableQueryable<ShoppingCartHeader, object>> include = null, bool asNotracking = false)
    {
        var query = (IQueryable<ShoppingCartHeader>)_dbSet;

        if (asNotracking)
            query = (IQueryable<ShoppingCartHeader>)_dbSet;

        if (include != null) 
            query = include(query);
            
        return await query.FirstOrDefaultAsync(sc => sc.Id == id);
    }

    public async Task<bool> SaveAsync(ShoppingCartHeader entity)
    {
        await _dbSet.AddAsync(entity);

        return await CommitInDbAsync();
    }

    public async Task<bool> UpdateAsync(ShoppingCartHeader entity)
    {
        _context.Entry(entity).State = EntityState.Modified;

        return await CommitInDbAsync();
    }
}
