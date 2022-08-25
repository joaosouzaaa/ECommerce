using ECommerce.OrderServiceAPI.RabbitMQConsumer;
using ECommerce.OrderServiceAPI.RabbitMQSender;

namespace ECommerce.OrderServiceAPI.Ioc;

public static class OthersDependencyInjection
{
    public static void AddOthersDependecyInjection(this IServiceCollection service)
    {
        service.AddScoped<IRabbitMQMessageSender, RabbitMQMessageSender>();
        service.AddHostedService<RabbitMQCheckoutConsumer>();
    }
}
