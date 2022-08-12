using ECommerce.CouponServiceAPI.Domain.Entities;
using ECommerce.CouponServiceAPI.Domain.Handlers.Validation.ValidationEntities;
using ECommerce.CouponServiceAPI.Domain.Interface;

namespace ECommerce.CouponServiceAPI.Ioc;

public static class ValidationDependencyInjection
{
    public static void AddValidationDependencyInjection(this IServiceCollection service)
    {
        service.AddScoped<IValidate<Coupon>, CouponValidation>();
    }
}
