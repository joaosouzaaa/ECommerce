using ECommerce.ProductServiceAPI.Domain.Handlers.Notification;
using Xunit;

namespace ECommerce.TestProductService.Notifications
{
    public class NotificationHandlerTest
    {
        private NotificationHandler _notificationHandler;

        public NotificationHandlerTest()
        {
            _notificationHandler = new NotificationHandler();
        }

        [Fact( DisplayName = "Notification")]
        [Trait("Sucess", "New Notification")]
        public async void NotificationHandle_CreateNewNotification_ReturnHasNotificationTrue()
        {
            _notificationHandler.AddNotification("Teste", "Nova notificação");

            Assert.True(_notificationHandler.HasNotification());
        }

        [Fact(DisplayName = "Notification")]
        [Trait("Sucess", "New Notification with bool returns")]
        public async void NotificationHandler_CreateNewNotificationWithBoolReturn_ReturnHasNotificationTrue()
        {
            var hasnotification = _notificationHandler.AddNotification(new DomainNotification("Teste", "Nova notificação"));

            Assert.True(_notificationHandler.HasNotification());
            Assert.True(!hasnotification);
        }

        [Fact(DisplayName = "Notification")]
        [Trait("Sucess", "New Notification List")]
        public async void NotificationHandler_CreateIEnumerableNotification_ReturnHasNotificationTrue()
        {

            var notifications = new List<DomainNotification>();
            notifications.Add(new DomainNotification("Teste 1", "Teste"));
            notifications.Add(new DomainNotification("Teste 2", "Teste"));
            notifications.Add(new DomainNotification("Teste 3", "Teste"));

            _notificationHandler.AddNotifications(notifications);

            Assert.True(_notificationHandler.HasNotification());
            Assert.True(_notificationHandler.GetNotifications().Count == 3);
        }

        [Fact(DisplayName = "Notification")]
        [Trait("Sucess", "New Notification Dictionary")]
        public async void NotificationHandler_CreateDictionaryNotification_ReturnHasNotificationTrue()
        {
            var notifications = new Dictionary<string, string>();
            notifications.Add("Teste 1", "Teste");
            notifications.Add("Teste 2", "Teste");
            notifications.Add("Teste 3", "Teste");

            _notificationHandler.AddNotifications(notifications);

            Assert.True(_notificationHandler.HasNotification());
            Assert.True(_notificationHandler.GetNotifications().Count == 3);
        }
    }
}
