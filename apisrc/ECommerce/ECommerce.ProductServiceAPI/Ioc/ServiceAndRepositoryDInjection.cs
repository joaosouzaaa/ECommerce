using ECommerce.ProductServiceAPI.ApplicationService.Services;
using ECommerce.ProductServiceAPI.Data.Repository;
using ECommerce.ProductServiceAPI.Domain.Interface.RepositoryContract;
using ECommerce.ProductServiceAPI.Domain.Interface.ServiceContract;

namespace ECommerce.ProductServiceAPI.Ioc;

public static class ServiceAndRepositoryDInjection
{
    public static void AddServiceDInjection(this IServiceCollection service)
    {
        service.AddScoped<IProductService, ProductService>();
        service.AddScoped<IProductTypeService, ProductTypeService>();
    }

    public static void AddRepositoryDInjection(this IServiceCollection service)
    {
        service.AddScoped<IProductRepository, ProductRepository>();
        service.AddScoped<IProductTypeRepository, ProductTypeRepository>();
    }
}
