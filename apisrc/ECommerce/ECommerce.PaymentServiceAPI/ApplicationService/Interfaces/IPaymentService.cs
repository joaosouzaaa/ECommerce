using ECommerce.PaymentServiceAPI.ApplicationService.Requests.Product;
using Stripe;
using Stripe.Checkout;

namespace ECommerce.PaymentServiceAPI.ApplicationService.Interfaces
{
    public interface IPaymentService
    {
        Task<Session> CreateSessionAsync(ProductsSaveRequest products);
        Task<Product> CreateProductAsync(ProductSaveRequest product);
        Task<StripeList<Product>> GetAllProductsAsync();
    }
}
