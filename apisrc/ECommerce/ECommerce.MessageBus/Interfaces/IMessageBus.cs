using ECommerce.MessageBus.Entities;

namespace ECommerce.MessageBus.Interfaces;

public interface IMessageBus
{
    Task PublicMessage(BaseMessage message, string topicName);
}
