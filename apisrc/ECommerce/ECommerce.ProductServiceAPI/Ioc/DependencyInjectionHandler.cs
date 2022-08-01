using ECommerce.ProductServiceAPI.ApplicationService.Services;
using ECommerce.ProductServiceAPI.Data.ORM.Context;
using ECommerce.ProductServiceAPI.Domain.Entities;
using ECommerce.ProductServiceAPI.Domain.Interface;
using ECommerce.ProductServiceAPI.Domain.Provider;
using ECommerce.ProductServiceAPI.Ioc;

namespace ECommerce.ProductServiceAPI.IoC;

public static class DependencyInjectionHandler
{
    public static void AddDIHandler(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ProductMySqlContext>();
        services.AddSingleton(configuration.GetSection("ConfigurationApplication").Get<ConfigurationApplication>());

        services.AddFiltersDependencyInjection();
        services.AddOthersDependecyInjection();
        services.AddValidationDependencyInjection();
        services.AddServiceDInjection();
        services.AddRepositoryDInjection();

        services.AddScoped<IPagingService<Product>, PagingService<Product>>();
        services.AddScoped<IPagingService<ProductType>, PagingService<ProductType>>();
    }
}
