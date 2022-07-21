using ECommerce.ProductServiceAPI.Domain.Enum;

namespace ECommerce.ProductServiceAPI.ApplicationService.DTOs.Response.ProductTypeResponse;

public class ProductTypeSearchResponse
{
    public int ProductTypeId { get; set; }
    public string Name { get; set; }
    public ECategory Category { get; set; }
}
