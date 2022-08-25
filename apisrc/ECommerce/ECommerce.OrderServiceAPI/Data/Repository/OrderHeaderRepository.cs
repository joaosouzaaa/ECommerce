using ECommerce.OrderServiceAPI.Data.ORM.Context;
using ECommerce.OrderServiceAPI.Domain.Entities;
using ECommerce.OrderServiceAPI.Domain.Interface.RepositoryContract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace ECommerce.OrderServiceAPI.Data.Repository;

public class OrderHeaderRepository : IOrderHeaderRepository
{
    private readonly OrderSqlServerContext _dbContext;
    private DbSet<OrderHeader> _dbSet => _dbContext.Set<OrderHeader>();

    public OrderHeaderRepository(OrderSqlServerContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Dispose() => _dbContext.Dispose();

    public async Task<OrderHeader> FindByAsync(int orderHeaderId, Func<IQueryable<OrderHeader>, IIncludableQueryable<OrderHeader, object>> include = null, bool asNoTracking = false) =>
        await IncludeMultiple(include, asNoTracking).FirstOrDefaultAsync(o => o.Id == orderHeaderId);

    private async Task<bool> SaveDbAsync() => await _dbContext.SaveChangesAsync() > 0;

    public async Task<bool> SaveAsync(OrderHeader orderHeader)
    {
        _dbSet.Add(orderHeader);
        return await SaveDbAsync();
    }

    public async Task<bool> UpdateAsync(OrderHeader orderHeader)
    {
        _dbContext.Update(orderHeader);
        _dbContext.Entry(orderHeader).State = EntityState.Modified;

        return await SaveDbAsync();
    }

    private IQueryable<OrderHeader> IncludeMultiple(Func<IQueryable<OrderHeader>, IIncludableQueryable<OrderHeader, object>> include = null, bool asNoTracking = false)
    {
        var query = (IQueryable<OrderHeader>)_dbSet;

        if (asNoTracking)
            query = _dbSet.AsNoTracking();

        if (include != null)
            query = include(query);

        return query;
    }
}
