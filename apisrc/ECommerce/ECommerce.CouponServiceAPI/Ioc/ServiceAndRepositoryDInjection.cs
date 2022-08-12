using ECommerce.CouponServiceAPI.ApplicationService.Services;
using ECommerce.CouponServiceAPI.Data.Repository;
using ECommerce.CouponServiceAPI.Domain.Interface.RepositoryContract;
using ECommerce.CouponServiceAPI.Domain.Interface.ServiceContract;

namespace ECommerce.CouponServiceAPI.Ioc;

public static class ServiceAndRepositoryDInjection
{
    public static void AddServiceDInjection(this IServiceCollection service)
    {
        service.AddScoped<ICouponService, CouponService>();
    }

    public static void AddRepositoryDInjection(this IServiceCollection service)
    {
        service.AddScoped<ICouponRepository, CouponRepository>();
    }
}
