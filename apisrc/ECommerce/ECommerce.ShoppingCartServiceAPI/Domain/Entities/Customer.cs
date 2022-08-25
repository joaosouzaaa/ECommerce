namespace ECommerce.ShoppingCartServiceAPI.Domain.Entities;

public class Customer : BaseEntity
{
    public string FisrtName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }

    public string UserId { get; set; }
    public int ShoppingCartHeaderId { get; set; }
}
