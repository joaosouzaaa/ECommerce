using ECommerce.CouponServiceAPI.Filters;

namespace ECommerce.CouponServiceAPI.Ioc;

public static class FiltersDependencyInjection
{
    public static void AddFiltersDependencyInjection(this IServiceCollection services)
    {
        services.AddMvc(configuration => configuration.Filters.AddService<NotificationFilter>());
        services.AddMvc(configuration => configuration.Filters.AddService<UnitOfWorkFilter>());

        services.AddScoped<NotificationFilter>();
        services.AddScoped<UnitOfWorkFilter>();
    }
}
