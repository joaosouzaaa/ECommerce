using ECommerce.CouponServiceAPI.Data.ORM.Uow;
using ECommerce.CouponServiceAPI.Domain.Handlers.Notification;
using ECommerce.CouponServiceAPI.Domain.Interface;
using ECommerce.CouponServiceAPI.RabbitMQSender;

namespace ECommerce.CouponServiceAPI.Ioc;

public static class OthersDependencyInjection
{
    public static void AddOthersDependecyInjection(this IServiceCollection service)
    {
        service.AddScoped<INotificationHandler, NotificationHandler>();
        service.AddScoped<IRabbitMQMessageSender, RabbitMQMessageSender>();
        //service.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
