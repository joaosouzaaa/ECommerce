using ECommerce.CouponServiceAPI.Domain.Handlers.Pagination;
using ECommerce.CouponServiceAPI.Domain.Interface;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.CouponServiceAPI.ApplicationService.Services;

public class PagingService<TEntity> : IPagingService<TEntity>
    where TEntity : class
{
    public async Task<PageList<TEntity>> CreatePaginationAsync(IQueryable<TEntity> source, int pageNumber, int pageSize)
    {
        var count = await source.CountAsync();
        var items = await source.Skip((pageNumber - 1)* pageSize).Take(pageSize).ToListAsync();

        return new PageList<TEntity>(items, count, pageNumber, pageSize);
    }
}
