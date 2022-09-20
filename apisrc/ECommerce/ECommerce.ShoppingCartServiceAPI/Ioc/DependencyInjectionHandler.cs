using ECommerce.ShoppingCartServiceAPI.ApplicationService.AutoMapperSettings;
using ECommerce.ShoppingCartServiceAPI.Data.ORM.Context;
using ECommerce.ShoppingCartServiceAPI.Domain.Handlers.Notification;
using ECommerce.ShoppingCartServiceAPI.Domain.Interface;
using ECommerce.ShoppingCartServiceAPI.Domain.Provider;
using ECommerce.ShoppingCartServiceAPI.Ioc;

namespace ECommerce.ShoppingCartServiceAPI.IoC;

public static class DependencyInjectionHandler
{
    public static void AddDIHandler(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddScoped<ShoppingCartContext>();
        services.AddSingleton(configuration.GetSection("ConfigurationApplication").Get<ConfigurationApplication>());
        services.AddScoped<INotificationHandler, NotificationHandler>();

        services.AddRepositoryDependencyInjection();
        services.AddValidationDependencyInjection();
        services.AddServiceDependencyInjection();

        AutoMapperConfigurations.Inicialize();
    }
}
