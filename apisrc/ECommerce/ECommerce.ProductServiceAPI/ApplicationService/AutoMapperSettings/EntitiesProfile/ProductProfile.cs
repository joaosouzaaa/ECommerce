using AutoMapper;
using ECommerce.ProductServiceAPI.ApplicationService.DTOs.Request.ProductRequest;
using ECommerce.ProductServiceAPI.ApplicationService.DTOs.Response.ProductResponse;
using ECommerce.ProductServiceAPI.Domain.Entities;

namespace ECommerce.ProductServiceAPI.ApplicationService.AutoMapperSettings.EntitiesProfile;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductSaveRequest>()
            .ForMember(pr => pr.Type, map => map.MapFrom(p => p.ProductType))
            .ReverseMap();

        CreateMap<Product, ProductUpdateRequest>()
           .ForMember(pr => pr.Type, map => map.MapFrom(p => p.ProductType))
           .ReverseMap();

        CreateMap<Product, ProductSearchResponse>()
           .ForMember(pr => pr.Type, map => map.MapFrom(p => p.ProductType))
           .ReverseMap();
    }
}
