namespace ECommerce.ShoppingCartServiceAPI.Domain.Entities;

public class CardPayment : BaseEntity
{
    public string CardNumber { get; set; }
    public string CVV { get; set; }
    public string ExpiryMonthYear { get; set; }

    public int ShoppingCartHeaderId { get; set; }
}
