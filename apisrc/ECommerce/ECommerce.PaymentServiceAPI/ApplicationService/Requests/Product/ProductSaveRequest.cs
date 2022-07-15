namespace ECommerce.PaymentServiceAPI.ApplicationService.Requests.Product
{
    public class ProductSaveRequest
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public ProductSaveRequest()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
