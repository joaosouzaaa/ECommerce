using ECommerce.ShoppingCartServiceAPI.ApplicationService.Interfaces.ShoppingCart;
using ECommerce.ShoppingCartServiceAPI.ApplicationService.Request;
using ECommerce.ShoppingCartServiceAPI.ApplicationService.Response;
using ECommerce.ShoppingCartServiceAPI.Domain.Handlers.Notification;
using ECommerce.ShoppingCartServiceAPI.RabbitMQSender;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.ShoppingCartServiceAPI.Controllers;

public class ShoppingCartController : Controller
{
    private readonly IShoppingCartService _shoppingCartService;

    public ShoppingCartController(IShoppingCartService shoppingCartService, IRabbitMQMessageSender rabbitMQMessageSender)
    {
        _shoppingCartService = shoppingCartService;
    }

    [HttpPost("set_async")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
    public async Task<bool> SetAsync([FromBody] ShoppingCartSaveRequest saveRequest) =>
        await _shoppingCartService.SetAsync(saveRequest);
    
    [HttpGet("get_async")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
    public async Task<ShoppingCartResponse> GetAsync([FromQuery] string key) =>
        await _shoppingCartService.GetAsync(key);

    [HttpDelete("remove_async")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task RemoveAsync([FromQuery] string key) =>
       await _shoppingCartService.RemoveAsync(key);

    [HttpPut("refresh_async")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
    public async Task RefreshAsync([FromQuery] string key) =>
       await _shoppingCartService.RefreshAsync(key);
}
