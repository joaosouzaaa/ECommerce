using ECommerce.OrderServiceAPI.Domain.Handlers.Pagination;

namespace ECommerce.OrderServiceAPI.Domain.Interface;

public interface IPagingService<TEntity> where TEntity : class
{
    Task<PageList<TEntity>> CreatePaginationAsync(IQueryable<TEntity> source, int pageNumber, int pageSize);
}
