using ECommerce.ProductServiceAPI.Data.ORM.Uow;
using ECommerce.ProductServiceAPI.Domain.Handlers.Notification;
using ECommerce.ProductServiceAPI.Domain.Interface;
using ECommerce.ProductServiceAPI.RabbitMQSender;

namespace ECommerce.ProductServiceAPI.Ioc;

public static class OthersDependencyInjection
{
    public static void AddOthersDependecyInjection(this IServiceCollection service)
    {
        service.AddScoped<INotificationHandler, NotificationHandler>();
        service.AddScoped<IRabbitMQMessageSender, RabbitMQMessageSender>();
        service.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
