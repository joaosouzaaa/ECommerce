using ECommerce.ShoppingCartServiceAPI.Domain.Interface;

namespace ECommerce.ShoppingCartServiceAPI.Domain.Handlers.Notification
{
    public class NotificationHandler : INotificationHandler
    {
        private List<DomainNotification> _notifications;

        public NotificationHandler()
        {
            _notifications = new List<DomainNotification>();
        }

        public List<DomainNotification> GetNotifications() => _notifications;

        public bool HasNotification() => _notifications.Any();

        public bool AddNotification(DomainNotification notification)
        {
            _notifications.Add(notification);

            return false;
        }

        public void AddNotification(string key, string value) =>
            _notifications.Add(new DomainNotification(key, value));

        public void AddNotifications(IEnumerable<DomainNotification> notifications) =>
            _notifications.AddRange(notifications);

        public void AddNotifications(Dictionary<string, string> notifications)
        {
            foreach (var notification in notifications)
                AddNotification(notification.Key, notification.Value);
        }
    }
}
