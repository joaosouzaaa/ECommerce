using ECommerce.CouponServiceAPI.ApplicationService.DTOs.Response;
using ECommerce.CouponServiceAPI.Domain.Interface.ServiceContract;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.CouponServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly ICouponService _couponService;

        public CouponController(ICouponService couponService)
        {
            _couponService = couponService;
        }

        [HttpGet("find_by_coupon")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public Task<CouponSearchResponse> Get(string couponCode) => 
            _couponService.FindByCouponCode(couponCode);
    }
}
