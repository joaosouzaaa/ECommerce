using ECommerce.PaymentServiceAPI.Domain.Handlers.Notification;

namespace ECommerce.PaymentServiceAPI.Domain.Interface
{
    public interface INotificationHandler
    {
        bool HasNotification();
        List<DomainNotification> GetNotifications();
        bool AddNotification(DomainNotification notification);
        void AddNotification(string key, string value);
        void AddNotifications(IEnumerable<DomainNotification> notifications);
        void AddNotifications(Dictionary<string, string> notifications);
    }
}
