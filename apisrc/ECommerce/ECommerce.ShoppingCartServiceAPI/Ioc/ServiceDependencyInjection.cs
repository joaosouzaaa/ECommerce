using ECommerce.ShoppingCartServiceAPI.ApplicationService.Interfaces.ShoppingCart;
using ECommerce.ShoppingCartServiceAPI.ApplicationService.Service;
using ECommerce.ShoppingCartServiceAPI.RabbitMQSender;

namespace ECommerce.ShoppingCartServiceAPI.Ioc
{
    public static class ServiceDependencyInjection
    {
        public static void AddServiceDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IShoppingCartService, ShoppingCartService>();
            services.AddScoped<IRabbitMQMessageSender, RabbitMQMessageSender>();
        }
    }
}
