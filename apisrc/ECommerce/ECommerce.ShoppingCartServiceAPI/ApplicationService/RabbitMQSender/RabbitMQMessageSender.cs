using ECommerce.MessageBus.Entities;
using ECommerce.ShoppingCartServiceAPI.ApplicationService.Request;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace ECommerce.ShoppingCartServiceAPI.RabbitMQSender;

public class RabbitMQMessageSender : IRabbitMQMessageSender
{
    private readonly string _hostName;
    private readonly string _password;
    private readonly string _userName;
    private IConnection _connection;

    public RabbitMQMessageSender()
    {
        _hostName = "localhost";
        _userName = "guest";
        _password = "guest";
    }

    public void SendMessage(BaseMessage message, string topicName)
    {
        var factory = new ConnectionFactory
        {
            HostName = _hostName,
            UserName = _userName,
            Password = _password
        };
        _connection = factory.CreateConnection();

        using var channel = _connection.CreateModel();
        channel.QueueDeclare(queue: topicName, false, false, false, arguments: null);
        var body = GetMessageAsByteArray(message);

        channel.BasicPublish(exchange: "", routingKey: topicName, basicProperties: null,
            body: body);
    }

    private byte[] GetMessageAsByteArray(BaseMessage message)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        var json = JsonSerializer.Serialize<AntigoCheckoutHeaderRequest>((AntigoCheckoutHeaderRequest)message, options);

        return Encoding.UTF8.GetBytes(json);
    }
}
