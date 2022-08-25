namespace ECommerce.ShoppingCartServiceAPI.Domain.Entities;

public class ShoppingCartHeader : BaseEntity
{
    public string? CouponCode { get; set; }
    public decimal PurchaseAmount { get; set; }
    public decimal DiscountAmount { get; set; }
    public int CartTotalItens { get; set; }
    public bool PaymentStatus { get; set; }

    public Customer Customer { get; set; }
    public CardPayment CardPayment { get; set; }
    public List<Product> Products { get; set; }
}
