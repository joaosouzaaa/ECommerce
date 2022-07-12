using ECommerce.ProductServiceAPI.Domain.Handlers.Validation;

namespace ECommerce.ProductServiceAPI.Domain.Interface;

public interface IValidate<TEntity> where TEntity : class
{
    ValidationResponse Validation(TEntity entity);
    Task<ValidationResponse> ValidationAsync(TEntity entity);
}
