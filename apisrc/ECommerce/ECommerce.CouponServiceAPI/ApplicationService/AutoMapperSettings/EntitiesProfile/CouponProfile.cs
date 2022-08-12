using AutoMapper;
using ECommerce.CouponServiceAPI.ApplicationService.DTOs.Response;
using ECommerce.CouponServiceAPI.Domain.Entities;

namespace ECommerce.CouponServiceAPI.ApplicationService.AutoMapperSettings.EntitiesProfile
{
    public class CouponProfile : Profile
    {
        public CouponProfile()
        {
            CreateMap<Coupon, CouponSearchResponse>();
        }
    }
}
