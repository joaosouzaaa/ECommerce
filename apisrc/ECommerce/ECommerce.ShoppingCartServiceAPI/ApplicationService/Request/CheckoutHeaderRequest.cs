using ECommerce.MessageBus.Entities;

namespace ECommerce.ShoppingCartServiceAPI.ApplicationService.Request;

public class CheckoutHeaderRequest : BaseMessage
{
    public string UserName { get; set; }
    public string CoupondCode { get; set; }
    public decimal PurchaseAmount { get; set; }
    public decimal DiscountAmount { get; set; }
    public string FirstName { get; set; }
}
