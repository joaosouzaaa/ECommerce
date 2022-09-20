using ECommerce.ShoppingCartServiceAPI.ApplicationService.Service;
using ECommerce.ShoppingCartServiceAPI.Data.Repository;
using ECommerce.ShoppingCartServiceAPI.Domain.Interface.RepositoryContract;
using ECommerce.ShoppingCartServiceAPI.Domain.Interface.ServiceContract;
using ECommerce.ShoppingCartServiceAPI.RabbitMQSender;

namespace ECommerce.ShoppingCartServiceAPI.Ioc
{
    public static class RepositoryAndServiceDependencyInjection
    {
        public static void AddRepositoryDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();
        }

        public static void AddServiceDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IShoppingCartService, ShoppingCartService>();
            services.AddScoped<IRabbitMQMessageSender, RabbitMQMessageSender>();
        }
    }
}
