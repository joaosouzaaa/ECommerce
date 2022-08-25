using ECommerce.MessageBus.Entities;

namespace ECommerce.ShoppingCartServiceAPI.RabbitMQSender;

public interface IRabbitMQMessageSender
{
    void SendMessage(BaseMessage baseMessage, string topicName);
}
