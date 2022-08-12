using ECommerce.CouponServiceAPI.Domain.Enum;
using ECommerce.CouponServiceAPI.Domain.Extensions;
using ECommerce.CouponServiceAPI.Domain.Handlers.Notification;
using ECommerce.CouponServiceAPI.Domain.Interface;

namespace ECommerce.CouponServiceAPI.ApplicationService.Services;

public class BaseService<TEntity> where TEntity : class
{
    private readonly IValidate<TEntity> _validate;
    protected readonly INotificationHandler _notification;

    public BaseService(IValidate<TEntity> validate, INotificationHandler notification)
    {
        _validate = validate;
        _notification = notification;
    }

    protected async Task<bool> ValidationAsync(TEntity entity)
    {
        if (_validate is null)
            return _notification.AddNotification(new DomainNotification("Invalid", EMessage.ErrorNotConfigured.Description()));

        var validationResponse = await _validate.ValidationAsync(entity);

        if (!validationResponse.Valid)
            _notification.AddNotifications(DomainNotification.Create(validationResponse.Errors));

        return validationResponse.Valid;

    }
}
