namespace ECommerce.ShoppingCartServiceAPI.Domain.Entities
{
    public class ShoppingCart
    {
        public string Id { get; set; }
        public int TotalItens { get; set; }
        public decimal TotalPrice { get; set; }

        public List<Product> Products { get; set; }
        //public DateTime CreateDate { get; set; }
        //public DateTime UpdateDate { get; set; }

        public ShoppingCart()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
