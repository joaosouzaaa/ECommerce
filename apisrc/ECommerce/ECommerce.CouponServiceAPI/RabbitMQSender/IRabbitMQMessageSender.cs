using ECommerce.MessageBus.Entities;

namespace ECommerce.CouponServiceAPI.RabbitMQSender;

public interface IRabbitMQMessageSender
{
    void SendMessage(BaseMessage baseMessage, string topicName);
}
