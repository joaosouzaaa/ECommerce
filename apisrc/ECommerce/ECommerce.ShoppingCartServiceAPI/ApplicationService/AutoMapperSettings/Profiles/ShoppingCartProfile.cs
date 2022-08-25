using AutoMapper;
using ECommerce.ShoppingCartServiceAPI.ApplicationService.Request;
using ECommerce.ShoppingCartServiceAPI.ApplicationService.Response;
using ECommerce.ShoppingCartServiceAPI.Domain.Entities;

namespace ECommerce.ShoppingCartServiceAPI.ApplicationService.AutoMapperSettings.Profiles
{
    public class ShoppingCartProfile : Profile
    {
        public ShoppingCartProfile()
        {
            CreateMap<ShoppingCartDatail, ShoppingCartSaveRequest>()
                .ForMember(sr => sr.ProductsSaveRequest, map => map.MapFrom(s => s.Product))
                .ReverseMap();

            CreateMap<ShoppingCartDatail, ShoppingCartResponse>()
                .ForMember(sr => sr.ProductsResponse, map => map.MapFrom(s => s.Product))
                .ReverseMap();
        }
    }
}
