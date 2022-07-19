using ECommerce.ShoppingCartServiceAPI.Domain.Entities;
using ECommerce.ShoppingCartServiceAPI.Domain.Interface;
using ECommerce.ShoppingCartServiceAPI.Domain.Provider;
using ECommerce.ShoppingCartServiceAPI.Ioc;

namespace ECommerce.ShoppingCartServiceAPI.IoC;

public static class DependencyInjectionHandler
{
    public static void AddDIHandler(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton(configuration.GetSection("ConnectionStrings").Get<ConfigurationApplication>());
        
        services.AddScoped<INotificationHandler>();

        services.AddScoped<IPagingService<ShoppingCart>>();

        services.AddValidationDependencyInjection();
    }
}
