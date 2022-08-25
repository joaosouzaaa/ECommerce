using ECommerce.OrderServiceAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;

namespace ECommerce.OrderServiceAPI.Domain.Interface.RepositoryContract;

public interface IOrderHeaderRepository : IDisposable
{
    Task<bool> SaveAsync(OrderHeader orderHeader);
    Task<bool> UpdateAsync(OrderHeader orderHeader);
    Task<OrderHeader> FindByAsync(int orderHeaderId, Func<IQueryable<OrderHeader>, IIncludableQueryable<OrderHeader, object>> include = null, bool asNoTracking = false);
}
