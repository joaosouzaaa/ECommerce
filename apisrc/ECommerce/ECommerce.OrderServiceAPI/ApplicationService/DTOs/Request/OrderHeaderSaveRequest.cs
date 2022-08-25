using ECommerce.OrderServiceAPI.ApplicationService.DTOs.Request.ValueObjectRequest;

namespace ECommerce.OrderServiceAPI.ApplicationService.DTOs.Request;

public class OrderHeaderSaveRequest
{
    public string? CouponCode { get; set; }
    public decimal PurchaseAmount { get; set; }
    public decimal DiscountAmount { get; set; }
    public int CartTotalItens { get; set; }
    public bool PaymentStatus { get; set; }

    public CustomerVORequest Customer { get; set; }
    public CardPaymentVORequest CardPayment { get; set; }
    public IEnumerable<OrderDetailSaveRequest> OrderDetails { get; set; }
}
