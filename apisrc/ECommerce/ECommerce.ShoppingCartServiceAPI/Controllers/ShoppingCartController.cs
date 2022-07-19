using ECommerce.ShoppingCartServiceAPI.ApplicationService.Response;
using ECommerce.ShoppingCartServiceAPI.Domain.Handlers.Notification;
using ECommerce.ShoppingCartServiceAPI.RabbitMQSender;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.ShoppingCartServiceAPI.Controllers;

public class ShoppingCartController : Controller
{
    private readonly IRabbitMQMessageSender _rabbitMQMessageSender;

    public ShoppingCartController(IRabbitMQMessageSender rabbitMQMessageSender)
    {
        _rabbitMQMessageSender = rabbitMQMessageSender;
    }

   //[ProducesResponseType(StatusCodes.Status200OK)]
   //[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
   //public async Task<ShoppingCartResponse> Get()
   // {

   // }
}
