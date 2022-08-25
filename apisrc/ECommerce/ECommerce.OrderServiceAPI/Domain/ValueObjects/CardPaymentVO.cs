namespace ECommerce.OrderServiceAPI.Domain.ValueObjects;

public class CardPaymentVO
{
    public string CardNumber { get; set; }
    public string CVV { get; set; }
    public string ExpiryMonthYear { get; set; }
}
