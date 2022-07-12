using ECommerce.PaymentServiceAPI.Domain.Handlers.Pagination;

namespace ECommerce.PaymentServiceAPI.Domain.Interface;

public interface IPagingService<TEntity> where TEntity : class
{
    Task<PageList<TEntity>> CreatePaginationAsync(IQueryable<TEntity> source, int pageNumber, int pageSize);
}
