using ECommerce.MessageBus.Entities;
using ECommerce.ShoppingCartServiceAPI.ApplicationService.DTOs.Request.MessageRequest;
using ECommerce.ShoppingCartServiceAPI.ApplicationService.DTOs.Request.ValueObjectRequest;

namespace ECommerce.ShoppingCartServiceAPI.ApplicationService.Request.MessageRequest;

public class CheckoutHeaderRequest : BaseMessage
{
    public int Id { get; set; }
    public string? CouponCode { get; set; }
    public decimal PurchaseAmount { get; set; }
    public decimal DiscountAmount { get; set; }
    public int CartTotalItens { get; set; }
    public bool PaymentStatus { get; set; }

    public CustomerVORequest Customer { get; set; }
    public CardPaymentVORequest CardPayment { get; set; }
    public IEnumerable<CartDatailRequest> CartDatail { get; set; }
}
