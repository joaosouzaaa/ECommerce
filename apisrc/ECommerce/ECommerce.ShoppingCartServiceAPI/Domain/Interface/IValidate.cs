using ECommerce.ShoppingCartServiceAPI.Domain.Handlers.Validation;

namespace ECommerce.ShoppingCartServiceAPI.Domain.Interface;

public interface IValidate<TEntity> where TEntity : class
{
    ValidationResponse Validation(TEntity entity);
    Task<ValidationResponse> ValidationAsync(TEntity entity);
}
