using ECommerce.ShoppingCartServiceAPI.Data.ORM.Context;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.ShoppingCartServiceAPI.IoC;

public static class DependencyInjectionHandler
{
    public static void AddDIHandler(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ShoppingCartSqlServerContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("ConnectionForProducts")));
    }
}
