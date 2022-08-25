namespace ECommerce.ShoppingCartServiceAPI.ApplicationService.DTOs.Request.MessageRequest;

public class ProductRequest
{
    public int ProductId { get; set; }
    public byte[] Image { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string? OtherDetails { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
