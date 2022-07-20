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
            CreateMap<ShoppingCart, ShoppingCartSaveRequest>()
                .ForMember(sr => sr.ProductsSaveRequest, map => map.MapFrom(s => s.Products))
                .ReverseMap();

            CreateMap<ShoppingCart, ShoppingCartResponse>()
                .ForMember(sr => sr.ProductsResponse, map => map.MapFrom(s => s.Products))
                .ReverseMap();
        }
    }
}
