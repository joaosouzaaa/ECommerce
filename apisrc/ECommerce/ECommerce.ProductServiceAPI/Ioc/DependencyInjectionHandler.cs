using ECommerce.ProductServiceAPI.ApplicationService.Services;
using ECommerce.ProductServiceAPI.ApplicationService.Services.Interfaces;
using ECommerce.ProductServiceAPI.Data.ORM.Context;
using ECommerce.ProductServiceAPI.Data.Repository;
using ECommerce.ProductServiceAPI.Domain.Entities;
using ECommerce.ProductServiceAPI.Domain.Handlers.Validation.ValidationEntities;
using ECommerce.ProductServiceAPI.Domain.Interface;
using ECommerce.ProductServiceAPI.Domain.Interface.RepositoryContract;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.ProductServiceAPI.IoC;

public static class DependencyInjectionHandler
{
    public static void AddDIHandler(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ProductMySqlContext>(options =>
        options.UseMySql(configuration.GetConnectionString("ConnectionForProducts"),
        new MySqlServerVersion(new Version(8, 0, 28))));


        services.AddScoped<IValidate<Product>, ProductValidation>();
        services.AddScoped<IValidate<ProductType>, ProductTypeValidation>();

        services.AddScoped<IPagingService<Product>, PagingService<Product>>();

        services.AddScoped<IProductRepository, ProductRepository>();

        services.AddScoped<IProductService, ProductService>();
    }
}
