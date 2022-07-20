namespace ECommerce.ShoppingCartServiceAPI.ApplicationService.Response;

public class ShoppingCartResponse
{
    public string Id { get; set; }
    public int TotalItens { get; set; }
    public decimal TotalPrice { get; set; }

    public List<ProductResponse> ProductsResponse { get; set; }
}
