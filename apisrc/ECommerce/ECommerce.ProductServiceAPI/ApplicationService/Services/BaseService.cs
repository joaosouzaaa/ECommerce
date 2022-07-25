using ECommerce.ProductServiceAPI.Domain.Enum;
using ECommerce.ProductServiceAPI.Domain.Extensions;
using ECommerce.ProductServiceAPI.Domain.Handlers.Notification;
using ECommerce.ProductServiceAPI.Domain.Interface;

namespace ECommerce.ProductServiceAPI.ApplicationService.Services;

public class BaseService<TEntity> where TEntity : class
{
    private readonly IValidate<TEntity> _validate;
    private readonly INotificationHandler _notification;

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
