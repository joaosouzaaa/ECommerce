using ECommerce.IdentityServiceAPI.Domain.Handlers.Validation;

namespace ECommerce.IdentityServiceAPI.Domain.Interface;

public interface IValidate<TEntity> where TEntity : class
{
    ValidationResponse Validation(TEntity entity);
    Task<ValidationResponse> ValidationAsync(TEntity entity);
}
