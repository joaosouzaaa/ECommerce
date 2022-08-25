namespace ECommerce.OrderServiceAPI.ApplicationService.DTOs.Request.MessageRequest;

public class CartDatailRequest
{
    public int CartHeaderId { get; set; }
    public ProductRequest Product { get; set; }
}
