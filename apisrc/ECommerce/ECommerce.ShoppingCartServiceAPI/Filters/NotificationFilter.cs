using ECommerce.ShoppingCartServiceAPI.Domain.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ECommerce.ShoppingCartServiceAPI.Filters;

public class NotificationFilter : ActionFilterAttribute
{
    private readonly INotificationHandler _notification;

    public NotificationFilter(INotificationHandler notification)
    {
        _notification = notification;
    }

    public override void OnActionExecuted(ActionExecutedContext context)
    {

        if (_notification.HasNotification())
            context.Result = new BadRequestObjectResult(_notification.GetNotifications());

        base.OnActionExecuted(context);
    }
}
