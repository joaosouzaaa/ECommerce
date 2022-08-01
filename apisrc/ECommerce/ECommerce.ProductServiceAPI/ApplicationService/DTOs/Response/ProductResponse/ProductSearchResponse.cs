using ECommerce.ProductServiceAPI.ApplicationService.DTOs.Response.ProductTypeResponse;

namespace ECommerce.ProductServiceAPI.ApplicationService.DTOs.Response.ProductResponse;

public class ProductSearchResponse
{
    public int ProductId { get; set; }
    public byte[]? Image { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string? OtherDetails { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }

    public ProductTypeSearchResponse ProductType { get; set; }
}
