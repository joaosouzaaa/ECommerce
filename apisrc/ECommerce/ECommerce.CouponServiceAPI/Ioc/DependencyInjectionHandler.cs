using ECommerce.CouponServiceAPI.ApplicationService.Services;
using ECommerce.CouponServiceAPI.Data.ORM.Context;
using ECommerce.CouponServiceAPI.Domain.Entities;
using ECommerce.CouponServiceAPI.Domain.Interface;
using ECommerce.CouponServiceAPI.Domain.Provider;
using ECommerce.CouponServiceAPI.Ioc;

namespace ECommerce.CouponServiceAPI.IoC;

public static class DependencyInjectionHandler
{
    public static void AddDIHandler(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<CouponSqlServerContext>();
        services.AddSingleton(configuration.GetSection("ConfigurationApplication").Get<ConfigurationApplication>());

        //services.AddFiltersDependencyInjection();
        services.AddOthersDependecyInjection();
        services.AddValidationDependencyInjection();
        services.AddServiceDInjection();
        services.AddRepositoryDInjection();
    }
}
