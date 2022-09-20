using ECommerce.ShoppingCartServiceAPI.ApplicationService.Request;
using ECommerce.ShoppingCartServiceAPI.ApplicationService.Response;
using ECommerce.ShoppingCartServiceAPI.Domain.Handlers.Notification;
using ECommerce.ShoppingCartServiceAPI.Domain.Interface.ServiceContract;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.ShoppingCartServiceAPI.Controllers;

public class ShoppingCartController : Controller
{
    private readonly IShoppingCartService _shoppingCartService;


    public ShoppingCartController(IShoppingCartService shoppingCartService)
    {
        _shoppingCartService = shoppingCartService;
    }

    [HttpPost("add_product")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
    public async Task<bool> Post([FromQuery] int shoppingCartId, ProductSaveRequest saveRequest) =>
        await _shoppingCartService.AddProductAsync(shoppingCartId, saveRequest);

    [HttpPut("add_coupon")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
    public async Task<bool> Put([FromQuery] int shoppingCartId, string CouponCode) =>
        await _shoppingCartService.AddCoupoum(shoppingCartId, CouponCode);
    
    [HttpPut("finalize_purchase")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
    public async Task<bool> Put([FromBody] FinalizePurchaseRequest finalizePurchaseRequest) =>
        await _shoppingCartService.FinalizePurchase(finalizePurchaseRequest);

    [HttpDelete("remove_product")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<bool> RemoveAsync([FromQuery] int shoppingCartId, ProductSaveRequest saveRequest) =>
       await _shoppingCartService.RemoveProductAsync(shoppingCartId, saveRequest);

    [HttpGet("get_shopping_cart")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
    public async Task<ShoppingCartResponse> Get([FromQuery] int shoppingCartId) =>
        await _shoppingCartService.GetShoppingCartAsync(shoppingCartId);
}
