using AutoMapper;
using ECommerce.ShoppingCartServiceAPI.ApplicationService.Request;
using ECommerce.ShoppingCartServiceAPI.ApplicationService.Response;
using ECommerce.ShoppingCartServiceAPI.Domain.Entities;

namespace ECommerce.ShoppingCartServiceAPI.ApplicationService.AutoMapperSettings.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductSaveRequest>()
                .ReverseMap();

            CreateMap<Product, ProductResponse>()
                .ReverseMap();
        }
    }
}
