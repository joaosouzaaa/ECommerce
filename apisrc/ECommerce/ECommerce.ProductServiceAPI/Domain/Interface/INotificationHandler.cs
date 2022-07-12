using ECommerce.ProductServiceAPI.Domain.Handlers.Notification;

namespace ECommerce.ProductServiceAPI.Domain.Interface
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
