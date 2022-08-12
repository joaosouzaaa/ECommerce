using ECommerce.OrderServiceAPI.ApplicationService.Services;
using ECommerce.OrderServiceAPI.Data.ORM.Context;
using ECommerce.OrderServiceAPI.Domain.Entities;
using ECommerce.OrderServiceAPI.Domain.Interface;
using ECommerce.OrderServiceAPI.Domain.Provider;
using ECommerce.OrderServiceAPI.Ioc;

namespace ECommerce.OrderServiceAPI.IoC;

public static class DependencyInjectionHandler
{
    public static void AddDIHandler(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<OrderSqlServerlContext>();
        services.AddSingleton(configuration.GetSection("ConfigurationApplication").Get<ConfigurationApplication>());

        services.AddFiltersDependencyInjection();
        services.AddOthersDependecyInjection();
        services.AddValidationDependencyInjection();
        services.AddServiceDInjection();
        services.AddRepositoryDInjection();
    }
}
