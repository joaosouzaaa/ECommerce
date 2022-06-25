using ECommerce.IdentityServiceAPI.Domain.Providers;

namespace ECommerce.IdentityServiceAPI.IoC;

public static class DependencyInjectionHandler
{
    public static void AddDIHandler(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddSingleton(configuration.GetSection("ConnectionStrings").Get<ConfigurationApplication>());
    }
}
