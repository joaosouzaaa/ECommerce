namespace ECommerce.ShoppingCartServiceAPI.ApplicationService.Request
{
    public class ShoppingCartSaveRequest
    {
        public int TotalItens { get; set; }
        public decimal TotalPrice { get; set; }

        public List<ProductSaveRequest> ProductsSaveRequest { get; set; }
    }
}
