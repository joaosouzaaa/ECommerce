
using System.Collections;

namespace ECommerce.ProductServiceAPI.Domain.Entities;

public class Product : BaseEntity
{
    public byte[]? Image { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string? OtherDetails { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }

    public int ProductTypeId { get; set; }
    public ProductType Type { get; set; }

}
