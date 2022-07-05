namespace ECommerce.ShoppingCartServiceAPI.Domain.Entities
{
    public class ShoppingCart : BaseEntity
    {
        public int TotalItens { get; set; }
        public decimal TotalPrice { get; set; }

        public List<Product> Products { get; set; }
    }
}
