using ECommerce.OrderServiceAPI.ApplicationService.DTOs.Request.MessageRequest;
using ECommerce.OrderServiceAPI.Domain.Entities;
using ECommerce.OrderServiceAPI.Domain.Interface.RepositoryContract;
using ECommerce.OrderServiceAPI.Domain.ValueObjects;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace ECommerce.OrderServiceAPI.RabbitMQConsumer;

public class RabbitMQCheckoutConsumer : BackgroundService
{
    private readonly IOrderHeaderRepository _orderHeaderRepository;
    private IConnection _connection;
    private IModel _modelChannel;
    private const string  _queue = "ChekoutQueue";

    public RabbitMQCheckoutConsumer(IOrderHeaderRepository orderHeaderRepository, IConnection connection, IModel modelChannel)
    {
        _orderHeaderRepository = orderHeaderRepository;
        _connection = SetFactoryConnection();
        _modelChannel = _connection.CreateModel();
        _modelChannel.QueueDeclare(_queue, false, false, false, null);
    }

    private IConnection SetFactoryConnection()
    {
        var factory = new ConnectionFactory 
        {
            HostName = "localhost",
            UserName = "guest",
            Password = "guest"
        };

        return factory.CreateConnection();
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        stoppingToken.ThrowIfCancellationRequested();

        var consumer = new EventingBasicConsumer(_modelChannel);

        consumer.Received += (channel, eventSetiings) =>
        {
            var content = Encoding.UTF8.GetString(eventSetiings.Body.ToArray());
            var dto = JsonSerializer.Deserialize<CheckoutHeaderRequest>(content);

            ProcessOrder(dto).GetAwaiter().GetResult();
            _modelChannel.BasicAck(eventSetiings.DeliveryTag, false);
        };

        _modelChannel.BasicConsume(_queue, false, consumer);
        return Task.CompletedTask;
    }

    private async Task ProcessOrder(CheckoutHeaderRequest dto)
    {
        var order = new OrderHeader
        {
            CouponCode = dto.CouponCode,
            PurchaseAmount = dto.PurchaseAmount,
            DiscountAmount = dto.DiscountAmount,
            PaymentStatus = dto.PaymentStatus,
            OrderDetails = new List<OrderDetail>(),
            CartTotalItens = dto.CartTotalItens,
            Customer = new CustomerVO
            {
                UserId = dto.Customer.UserId,
                Email = dto.Customer.Email,
                FisrtName = dto.Customer.FisrtName,
                LastName = dto.Customer.LastName,
                Phone = dto.Customer.Phone
            },
            CardPayment = new CardPaymentVO
            {
                CardNumber = dto.CardPayment.CardNumber,
                ExpiryMonthYear = dto.CardPayment.ExpiryMonthYear,
                CVV = dto.CardPayment.CVV
            }
        };


        foreach (var datails in dto.CartDatail)
        {
            var orderDatail = new OrderDetail
            {
                ProductId = datails.Product.ProductId,
                ProductName = datails.Product.Name,
                Quantity = datails.Product.Quantity,
                Price = datails.Product.Price,
            };
            order.OrderDetails.Add(orderDatail);
        }

        await _orderHeaderRepository.SaveAsync(order);
    }
}
