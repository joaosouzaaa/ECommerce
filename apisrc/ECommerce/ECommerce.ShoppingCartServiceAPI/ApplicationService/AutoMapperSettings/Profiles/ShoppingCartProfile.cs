using AutoMapper;
using ECommerce.ShoppingCartServiceAPI.ApplicationService.Request;
using ECommerce.ShoppingCartServiceAPI.ApplicationService.Request.MessageRequest;
using ECommerce.ShoppingCartServiceAPI.ApplicationService.Response;
using ECommerce.ShoppingCartServiceAPI.Domain.Entities;

namespace ECommerce.ShoppingCartServiceAPI.ApplicationService.AutoMapperSettings.Profiles
{
    public class ShoppingCartProfile : Profile
    {
        public ShoppingCartProfile()
        {
            CreateMap<ShoppingCartHeader, ShoppingCartSaveRequest>()
                .ForMember(sr => sr.ProductsSaveRequest, map => map.MapFrom(s => s.Products))
                .ReverseMap();

            CreateMap<ShoppingCartHeader, ShoppingCartResponse>()
                .ForMember(sr => sr.ProductsResponse, map => map.MapFrom(s => s.Products))
                .ReverseMap();

            CreateMap<ShoppingCartHeader, CheckoutHeaderRequest>()
               .ForMember(sr => sr.Products, map => map.MapFrom(s => s.Products))
               .ForMember(sr => sr.Customer, map => map.MapFrom(s => s.Customer))
               .ForMember(sr => sr.CardPayment, map => map.MapFrom(s => s.CardPayment))
               .ReverseMap();
        }
    }
}
