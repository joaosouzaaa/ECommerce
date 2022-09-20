namespace ECommerce.ShoppingCartServiceAPI.ApplicationService.Response
{
    public class ProductResponse
    {
        public int Id { get; set; }
        public byte[]? Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? OtherDetails { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public int ProductTypeId { get; set; }
    }
}
