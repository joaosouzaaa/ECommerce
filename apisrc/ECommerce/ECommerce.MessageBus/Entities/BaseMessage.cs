namespace ECommerce.MessageBus.Entities;

public class BaseMessage
{
    public int MessageId { get; set; }
    public DateTime MessageCreated { get; set; }
}
