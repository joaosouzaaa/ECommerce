using ECommerce.OrderServiceAPI.Domain.ValueObjects;

namespace ECommerce.OrderServiceAPI.Domain.Entities;

public class OrderHeader : BaseEntity
{
    public string? CouponCode { get; set; }
    public decimal PurchaseAmount { get; set; }
    public decimal DiscountAmount { get; set; }
    public int CartTotalItens { get; set; }
    public bool PaymentStatus { get; set; }

    public CustomerVO Customer { get; set; }
    public CardPaymentVO CardPayment { get; set; }
    public List<OrderDetail> OrderDetails { get; set; }
}
