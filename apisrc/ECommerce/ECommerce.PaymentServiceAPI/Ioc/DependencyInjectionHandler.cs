using ECommerce.PaymentServiceAPI.Ioc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.PaymentServiceAPI.IoC;

public static class DependencyInjectionHandler
{
    public static void AddDIHandler(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOthersConfigurations();
        services.AddServicesConfiguration();
    }
}
