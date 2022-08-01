using ECommerce.MessageBus.Entities;

namespace ECommerce.ProductServiceAPI.RabbitMQSender;

public interface IRabbitMQMessageSender
{
    void SendMessage(BaseMessage baseMessage, string topicName);
}
