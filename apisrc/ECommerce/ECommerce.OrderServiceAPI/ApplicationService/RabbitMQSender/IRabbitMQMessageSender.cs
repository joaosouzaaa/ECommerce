using ECommerce.MessageBus.Entities;

namespace ECommerce.OrderServiceAPI.RabbitMQSender;

public interface IRabbitMQMessageSender
{
    void SendMessage(BaseMessage baseMessage, string topicName);
}
