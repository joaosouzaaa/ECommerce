namespace ECommerce.OrderServiceAPI.Domain.Entities;

public class OrderDetail : BaseEntity
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }

    public int OrderHeaderId { get; set; }
    public OrderHeader OrderHeader { get; set; }
}