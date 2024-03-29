﻿using ECommerce.ProductServiceAPI.Domain.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ECommerce.ProductServiceAPI.Filters
{
    public class NotificationFilter : ActionFilterAttribute
    {
        private readonly INotificationHandler _notification;

        public NotificationFilter(INotificationHandler notification)
        {
            _notification = notification;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (!ExternalMethodFilter.IsMethodGet(context) && _notification.HasNotification())
                context.Result = new BadRequestObjectResult(_notification.GetNotifications());

            base.OnActionExecuted(context);
        }
    }
}
