using ECommerce.ShoppingCartServiceAPI.Domain.Entities;
using ECommerce.ShoppingCartServiceAPI.Domain.Interface;

namespace ECommerce.ShoppingCartServiceAPI.Ioc
{
    public static class PagingDependencyInjection
    {
        public static void AddPagingDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IPagingService<ShoppingCart>>();
        }
    }
}
