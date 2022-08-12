using ECommerce.OrderServiceAPI.Domain.Handlers.Validation;

namespace ECommerce.OrderServiceAPI.Domain.Interface;

public interface IValidate<TEntity> where TEntity : class
{
    ValidationResponse Validation(TEntity entity);
    Task<ValidationResponse> ValidationAsync(TEntity entity);
}
