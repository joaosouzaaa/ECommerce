using System.Linq.Expressions;

namespace ECommerce.PaymentServiceAPI.Domain.Interface.RepositoryContract;

public interface IBaseCommandsRepository<TKey, TEntity>
    where TEntity : class
{
    Task<bool> SaveAsync(TEntity entity);
    Task<bool> UpdateAsync(TEntity entity);
    Task<bool> DeleteAsync(TKey id);
    Task<bool> HaveObjectInDb(Expression<Func<TEntity, bool>> where);
}
