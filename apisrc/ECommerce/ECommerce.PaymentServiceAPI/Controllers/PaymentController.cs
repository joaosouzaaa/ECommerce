using ECommerce.PaymentServiceAPI.ApplicationService.Interfaces;
using ECommerce.PaymentServiceAPI.ApplicationService.Requests.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe.Checkout;

namespace ECommerce.PaymentServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        
        [HttpPost("create-product")]
        public async Task<Product> CreateProductAsync(ProductSaveRequest productSaveRequest) =>
            await _paymentService.CreateProductAsync(productSaveRequest);

        [HttpPost("create-session")]
        public async Task<ActionResult> CreateSessionAsync(ProductsSaveRequest productsSaveRequest)
        {
            var session = await _paymentService.CreateSessionAsync(productsSaveRequest);
            
            Response.Headers.Add("Location", session.Url);

            return new StatusCodeResult(303);
        }
    }
}
