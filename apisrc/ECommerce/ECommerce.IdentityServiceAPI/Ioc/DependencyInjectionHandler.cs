using ECommerce.IdentityServiceAPI.Ioc.DIServices;
using ECommerce.ShoppingCartServiceAPI.Domain.Providers;

namespace ECommerce.ShoppingCartServiceAPI.IoC;

public static class DependencyInjectionHandler
{
    public static void AddDIHandler(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddSingleton(configuration.GetSection("ConnectionStrings").Get<ConfigurationApplication>());

        services.AddIdentityDIConfiguration();
    }
}
