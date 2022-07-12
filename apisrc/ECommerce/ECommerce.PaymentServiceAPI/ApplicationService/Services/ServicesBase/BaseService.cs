using ECommerce.PaymentServiceAPI.Domain.Interface;

namespace ECommerce.PaymentServiceAPI.ApplicationService.Services.ServicesBase
{
    public class BaseService
    {
        protected readonly INotificationHandler _notification;

        public BaseService(INotificationHandler notification)
        {
            _notification = notification;
        }
    }
}
