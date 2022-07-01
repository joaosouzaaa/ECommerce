using ECommerce.PaymentServiceAPI.Domain.Handlers.Validation;

namespace ECommerce.PaymentServiceAPI.Domain.Interface;

public interface IValidate<TEntity> where TEntity : class
{
    ValidationResponse Validation(TEntity entity);
    Task<ValidationResponse> ValidationAsync(TEntity entity);
}
