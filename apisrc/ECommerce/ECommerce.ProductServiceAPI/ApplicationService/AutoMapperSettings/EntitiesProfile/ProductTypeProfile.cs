using AutoMapper;
using ECommerce.ProductServiceAPI.ApplicationService.DTOs.Request.ProductTypeRequest;
using ECommerce.ProductServiceAPI.ApplicationService.DTOs.Response.ProductTypeResponse;
using ECommerce.ProductServiceAPI.Domain.Entities;
using ECommerce.ProductServiceAPI.Domain.Handlers.Pagination;

namespace ECommerce.ProductServiceAPI.ApplicationService.AutoMapperSettings.EntitiesProfile;

public class ProductTypeProfile : Profile
{
    public ProductTypeProfile()
    {
        CreateMap<ProductType, ProductTypeSaveRequest>()
            .ForMember(ptr => ptr.Category, map => map.MapFrom(pt => pt.Category))
            .ReverseMap(); 
        
        
        CreateMap<ProductType, ProductTypeUpdateRequest>()
            .ForMember(ptr => ptr.ProductTypeId, map => map.MapFrom(pt => pt.Id))
            .ForMember(ptr => ptr.Category, map => map.MapFrom(pt => pt.Category))
            .ReverseMap();


        CreateMap<ProductType, ProductTypeSearchResponse>()
            .ForMember(ptr => ptr.Category, map => map.MapFrom(pt => pt.Category));

        CreateMap<PageList<ProductType>, PageList<ProductTypeSearchResponse>>();
    }
}
