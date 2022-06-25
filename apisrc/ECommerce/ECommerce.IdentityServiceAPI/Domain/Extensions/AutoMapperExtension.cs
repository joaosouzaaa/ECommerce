using ECommerce.IdentityServiceAPI.ApplicationService.AutoMapperSettings;

namespace ECommerce.IdentityServiceAPI.Domain.Extensions;

public static class AutoMapperExtension
{
    public static TDestination MapTo<TSource, TDestination>(this TSource source)
    {
        return AutoMapperConfigurations.Mapper.Map<TSource, TDestination>(source);
    }

    public static TDestination MapTo<TSource, TDestination>(this TSource source, TDestination destination)
    {
        return AutoMapperConfigurations.Mapper.Map(source, destination);
    }
}