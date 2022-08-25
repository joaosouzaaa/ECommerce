using ECommerce.OrderServiceAPI.Data.ORM.Context;
using ECommerce.OrderServiceAPI.Domain.Provider;
using ECommerce.OrderServiceAPI.Ioc;

namespace ECommerce.OrderServiceAPI.IoC;

public static class DependencyInjectionHandler
{
    public static void AddDIHandler(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<OrderSqlServerContext>();
        services.AddSingleton(configuration.GetSection("ConfigurationApplication").Get<ConfigurationApplication>());

        services.AddOthersDependecyInjection();
        services.AddRepositoryDInjection();
    }
}
