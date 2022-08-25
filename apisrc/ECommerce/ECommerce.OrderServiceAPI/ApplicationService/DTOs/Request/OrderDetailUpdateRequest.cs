namespace ECommerce.OrderServiceAPI.ApplicationService.DTOs.Request;

public class OrderDetailUpdateRequest
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public int Count { get; set; }
    public decimal Price { get; set; }
}
