using ECommerce.ProductServiceAPI.Data.ORM.Context;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.ProductServiceAPI.IoC;

public static class DependencyInjectionHandler
{
    public static void AddDIHandler(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ProductMySqlContext>(options =>
        options.UseMySql(configuration.GetConnectionString("ConnectionForProducts"),
        new MySqlServerVersion(new Version(8, 0, 28))));
    }
}
