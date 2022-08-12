using ECommerce.OrderServiceAPI.ApplicationService.AutoMapperSettings;

namespace ECommerce.OrderServiceAPI.Domain.Extensions;

public static class AutoMapperExtension
{
    public static TDestination MapTo<TSource, TDestination>(this TSource source) => 
         AutoMapperConfigurations.Mapper.Map<TSource, TDestination>(source);

    public static TDestination MapTo<TSource, TDestination>(this TSource source, TDestination destination) =>
        AutoMapperConfigurations.Mapper.Map(source, destination);

}