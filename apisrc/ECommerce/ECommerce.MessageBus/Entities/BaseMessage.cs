namespace ECommerce.MessageBus.Entities;

public class BaseMessage
{
    public int Id { get; set; }
    public DateTime MessageCreated { get; set; }
}
