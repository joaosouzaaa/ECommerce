using ECommerce.PaymentServiceAPI.Data.ORM.Context;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.PaymentServiceAPI.IoC;

public static class DependencyInjectionHandler
{
    public static void AddDIHandler(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<PaymentSqlServerContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("ConnectionForProducts")));
    }
}
