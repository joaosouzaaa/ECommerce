using ECommerce.CouponServiceAPI.ApplicationService.DTOs.Response;
using ECommerce.CouponServiceAPI.Domain.Entities;
using ECommerce.CouponServiceAPI.Domain.Extensions;
using ECommerce.CouponServiceAPI.Domain.Interface.RepositoryContract;
using ECommerce.CouponServiceAPI.Domain.Interface.ServiceContract;

namespace ECommerce.CouponServiceAPI.ApplicationService.Services
{
    public class CouponService : ICouponService
    {
        private readonly ICouponRepository _couponRepository;

        public CouponService(ICouponRepository couponRepository)
        {
            _couponRepository = couponRepository;
        }

        public async Task<CouponSearchResponse> FindByCouponCode(string couponCode)
        {
            var couponRespose = await _couponRepository.FindCouponByCode(c => c.CouponCode == couponCode);

            return couponRespose.MapTo<Coupon, CouponSearchResponse>();
        }
    }
}
