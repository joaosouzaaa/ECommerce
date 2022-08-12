using ECommerce.CouponServiceAPI.Domain.Handlers.Validation;

namespace ECommerce.CouponServiceAPI.Domain.Interface;

public interface IValidate<TEntity> where TEntity : class
{
    ValidationResponse Validation(TEntity entity);
    Task<ValidationResponse> ValidationAsync(TEntity entity);
}
