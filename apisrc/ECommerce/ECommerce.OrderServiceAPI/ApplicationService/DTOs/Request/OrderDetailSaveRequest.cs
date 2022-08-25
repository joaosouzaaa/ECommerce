namespace ECommerce.OrderServiceAPI.ApplicationService.DTOs.Request;

public class OrderDetailSaveRequest
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
