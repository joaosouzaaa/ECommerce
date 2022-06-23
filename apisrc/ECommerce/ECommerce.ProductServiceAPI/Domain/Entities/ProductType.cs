using ECommerce.ProductServiceAPI.Domain.Enum;

namespace ECommerce.ProductServiceAPI.Domain.Entities;

public class ProductType : BaseEntity
{
    public string Name { get; set; }
    public ECategory Category { get; set; }

    public List<Product> Products { get; set; }
}
