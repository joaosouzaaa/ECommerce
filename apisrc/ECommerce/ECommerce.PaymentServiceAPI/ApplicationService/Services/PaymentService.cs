using ECommerce.PaymentServiceAPI.ApplicationService.Interfaces;
using ECommerce.PaymentServiceAPI.ApplicationService.Requests.Product;
using Stripe;
using Stripe.Checkout;

namespace ECommerce.PaymentServiceAPI.ApplicationService.Services
{
    public class PaymentService : IPaymentService
    {
        public SessionService SessionService { get; set; }
        public ProductService ProductService { get; set; }
        public PriceService PriceService { get; set; }

        public PaymentService()
        {
            ProductService = new ProductService();
            SessionService = new SessionService();
            PriceService = new PriceService();
        }

        public async Task<Session> CreateSessionAsync(ProductsSaveRequest products)
        {
            var productsList = new List<SessionLineItemOptions>();

            foreach (var productId in products.ProductsIds)
            {
                var product = await ProductService.GetAsync(productId);
                var priceData = await PriceService.GetAsync(product.DefaultPriceId);

                var sessionLineItem = new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmountDecimal = priceData.UnitAmountDecimal,
                        Product = productId,
                        Currency = priceData.Currency,
                    },
                    Quantity = 1
                };

                productsList.Add(sessionLineItem);
            }

            var options = new SessionCreateOptions
            {
                LineItems = productsList,
                Mode = "payment",
                SuccessUrl = "https://localhost:3000/sucess",
                CancelUrl = "https://localhost:3000/fail"
            };

            return await SessionService.CreateAsync(options);
        }

        public async Task<Product> CreateProductAsync(ProductSaveRequest product)
        {
            var options = new ProductCreateOptions
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                DefaultPriceData = new ProductDefaultPriceDataOptions
                {
                    UnitAmountDecimal = product.Price,
                    Currency = "brl",
                }
            };

            return await ProductService.CreateAsync(options);
        }

        public async Task<StripeList<Product>> GetAllProductsAsync() =>
            await ProductService.ListAsync();
    }
}
