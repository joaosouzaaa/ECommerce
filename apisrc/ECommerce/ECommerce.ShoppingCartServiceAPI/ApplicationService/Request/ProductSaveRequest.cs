namespace ECommerce.ShoppingCartServiceAPI.ApplicationService.Request
{
    public class ProductSaveRequest
    {
        public byte[] Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? OtherDetails { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
