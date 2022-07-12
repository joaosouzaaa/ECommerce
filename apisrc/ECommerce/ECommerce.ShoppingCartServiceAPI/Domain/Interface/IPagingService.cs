using ECommerce.ShoppingCartServiceAPI.Domain.Handlers.Pagination;

namespace ECommerce.ShoppingCartServiceAPI.Domain.Interface;

public interface IPagingService<TEntity> where TEntity : class
{
    Task<PageList<TEntity>> CreatePaginationAsync(IQueryable<TEntity> source, int pageNumber, int pageSize);
}
