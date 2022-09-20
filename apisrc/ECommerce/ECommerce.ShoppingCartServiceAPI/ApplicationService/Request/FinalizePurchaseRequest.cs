using ECommerce.ShoppingCartServiceAPI.ApplicationService.DTOs.Request.ValueObjectRequest;

namespace ECommerce.ShoppingCartServiceAPI.ApplicationService.Request;

public class FinalizePurchaseRequest
{
    public int ShoppingCartId { get; set; }
    public CustomerVORequest Customer { get; set; }
    public CardPaymentVORequest CardPayment { get; set; }
}
