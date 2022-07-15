using ECommerce.PaymentServiceAPI.ApplicationService.Interfaces;
using ECommerce.PaymentServiceAPI.ApplicationService.Services;

namespace ECommerce.PaymentServiceAPI.Ioc
{
    public static class ServicesConfiguration
    {
        public static void AddServicesConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IPaymentService, PaymentService>();
        }
    }
}
