using ECommerce.IdentityServiceAPI.Data.ORM.Context;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.IdentityServiceAPI.IoC;

public static class DependencyInjectionHandler
{
    public static void AddDIHandler(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<PaymentSqlServerContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("ConnectionForProducts")));
    }
}
