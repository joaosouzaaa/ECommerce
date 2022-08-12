using ECommerce.OrderServiceAPI.Data.ORM.Uow;
using ECommerce.OrderServiceAPI.Domain.Handlers.Notification;
using ECommerce.OrderServiceAPI.Domain.Interface;
using ECommerce.OrderServiceAPI.RabbitMQSender;

namespace ECommerce.OrderServiceAPI.Ioc;

public static class OthersDependencyInjection
{
    public static void AddOthersDependecyInjection(this IServiceCollection service)
    {
        service.AddScoped<INotificationHandler, NotificationHandler>();
        service.AddScoped<IRabbitMQMessageSender, RabbitMQMessageSender>();
        service.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
