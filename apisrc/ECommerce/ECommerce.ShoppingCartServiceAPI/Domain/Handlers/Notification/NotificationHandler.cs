using ECommerce.ShoppingCartServiceAPI.Domain.Interface;

namespace ECommerce.ShoppingCartServiceAPI.Domain.Handlers.Notification
{
    public class NotificationHandler : INotificationHandler
    {
        private List<DomainNotification> _notifications;

        public NotificationHandler()
        {
            this._notifications = new List<DomainNotification>();
        }

        public List<DomainNotification> GetNotifications() => this._notifications;

        public bool HasNotification() => this._notifications.Any();

        public bool AddNotification(DomainNotification notification)
        {
            this._notifications.Add(notification);

            if (this._notifications.Any() == true)
                return false;
            else
                return true;
        }

        public void AddNotification(string key, string value)
        {
            this._notifications.Add(new DomainNotification(key, value));
        }

        public void AddNotifications(IEnumerable<DomainNotification> notifications)
        {
            this._notifications.AddRange(notifications);
        }

        public void AddNotifications(Dictionary<string, string> notifications)
        {
            foreach (var notification in notifications)
            {
                AddNotification(notification.Key, notification.Value);
            }
        }
    }
}
