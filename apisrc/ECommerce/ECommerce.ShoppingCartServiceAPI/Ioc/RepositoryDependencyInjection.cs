using ECommerce.ShoppingCartServiceAPI.Data.Repository;
using ECommerce.ShoppingCartServiceAPI.Domain.Interface.RepositoryContract;

namespace ECommerce.ShoppingCartServiceAPI.Ioc
{
    public static class RepositoryDependencyInjection
    {
        public static void AddRepositoryDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();
        }
    }
}
