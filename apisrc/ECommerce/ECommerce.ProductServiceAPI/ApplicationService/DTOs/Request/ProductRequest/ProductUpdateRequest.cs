using ECommerce.ProductServiceAPI.ApplicationService.DTOs.Request.ProductTypeRequest;

namespace ECommerce.ProductServiceAPI.ApplicationService.DTOs.Request.ProductRequest;

public class ProductUpdateRequest
{
    public int ProductId { get; set; }
    public byte[]? Image { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string? OtherDetails { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }

    public int ProductTypeId { get; set; }
    public ProductTypeUpdateRequest Type { get; set; }
}
