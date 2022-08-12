using ECommerce.CouponServiceAPI.ApplicationService.DTOs.Response;

namespace ECommerce.CouponServiceAPI.Domain.Interface.ServiceContract
{
    public interface ICouponService
    {
        Task<CouponSearchResponse> FindByCouponCode(string couponCode);
    }
}
