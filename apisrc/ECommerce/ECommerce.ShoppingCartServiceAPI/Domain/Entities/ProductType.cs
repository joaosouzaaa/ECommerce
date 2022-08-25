using ECommerce.ShoppingCartServiceAPI.Domain.Enum;

namespace ECommerce.ShoppingCartServiceAPI.Domain.Entities;

public class ProductType : BaseEntity
{
    public string Name { get; set; }
    public ECategory Category { get; set; }

    public List<Product> Products { get; set; }
}
