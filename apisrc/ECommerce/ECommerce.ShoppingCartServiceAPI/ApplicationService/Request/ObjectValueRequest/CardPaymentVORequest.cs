namespace ECommerce.ShoppingCartServiceAPI.ApplicationService.DTOs.Request.ValueObjectRequest;

public class CardPaymentVORequest
{
    public string CardNumber { get; set; }
    public string CVV { get; set; }
    public string ExpiryMonthYear { get; set; }
}
