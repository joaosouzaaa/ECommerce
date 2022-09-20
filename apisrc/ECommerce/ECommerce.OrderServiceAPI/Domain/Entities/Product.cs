namespace ECommerce.OrderServiceAPI.Domain.Entities;

public class Product : BaseEntity
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public int Amount { get; set; }
    public decimal Price { get; set; }

    public int OrderHeaderId { get; set; }
    public OrderHeader OrderHeader { get; set; }
}