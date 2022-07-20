using ECommerce.ShoppingCartServiceAPI.ApplicationService.AutoMapperSettings;
using ECommerce.ShoppingCartServiceAPI.Domain.Entities;
using ECommerce.ShoppingCartServiceAPI.Domain.Handlers.Notification;
using ECommerce.ShoppingCartServiceAPI.Domain.Interface;
using ECommerce.ShoppingCartServiceAPI.Domain.Provider;
using ECommerce.ShoppingCartServiceAPI.Ioc;

namespace ECommerce.ShoppingCartServiceAPI.IoC;

public static class DependencyInjectionHandler
{
    public static void AddDIHandler(this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddDistributedMemoryCache(); 

        services.AddStackExchangeRedisCache(options => { options.Configuration = configuration["RedisCacheUrl"]; });
        services.AddScoped<INotificationHandler, NotificationHandler>();

        services.AddRepositoryDependencyInjection();
        services.AddValidationDependencyInjection();
        services.AddServiceDependencyInjection();

        AutoMapperConfigurations.Inicialize();
    }
}
