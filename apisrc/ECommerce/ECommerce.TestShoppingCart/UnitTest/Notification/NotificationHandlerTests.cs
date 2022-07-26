using ECommerce.ShoppingCartServiceAPI.Domain.Handlers.Notification;

namespace ECommerce.TestShoppingCart.UnitTest.Notification
{
    public class NotificationHandlerTests
    {
        NotificationHandler _notification;

        public NotificationHandlerTests()
        {
            _notification = new NotificationHandler();
        }

        [Fact]
        public void CheckNotifications_AddNotification()
        {
            _notification.AddNotification("notification key", "notification value");

            var notifications = _notification.GetNotifications();
            var hasNotification = _notification.HasNotification();

            Assert.NotNull(notifications);
            Assert.True(hasNotification);
        }

        [Fact]
        public void CheckNotifications_AddDomainNotification()
        {
            var addNotification = _notification.AddNotification(new DomainNotification("notification key", "notification value"));

            var notifications = _notification.GetNotifications();
            var hasNotification = _notification.HasNotification();

            Assert.False(addNotification);
            Assert.NotNull(notifications);
            Assert.True(hasNotification);
        }

        [Fact]
        public void AddNotifications_HaveNotifications()
        {
            var notificationsDicionary = new Dictionary<string, string>();
            notificationsDicionary.Add("notification key", "notification value");
            notificationsDicionary.Add("notification key different", "notification value different");
            _notification.AddNotifications(notificationsDicionary);

            var notifications = _notification.GetNotifications();
            var hasNotification = _notification.HasNotification();

            Assert.NotNull(notifications);
            Assert.True(hasNotification);
        }

        [Fact]
        public void AddNotificationList_HaveNotifications()
        {
            var notificationList = new List<DomainNotification>();
            notificationList.Add(new DomainNotification("notification key", "value"));
            notificationList.Add(new DomainNotification("notification key changed", "notification value"));
            _notification.AddNotifications(notificationList);

            var notifications = _notification.GetNotifications();
            var hasNotification = _notification.HasNotification();

            Assert.NotNull(notifications);
            Assert.True(hasNotification);
        }

        [Fact]
        public void DoesNotHaveAnyNotifications()
        {
            var notifications = _notification.GetNotifications();
            var hasNotification = _notification.HasNotification();

            Assert.Empty(notifications);
            Assert.Equal(0, notifications.Count);
            Assert.False(hasNotification);
        }
    }
}
