using ECommerce.ProductServiceAPI.Domain.Entities;
using ECommerce.ProductServiceAPI.Domain.Handlers.Validation.ValidationEntities;
using ECommerce.ProductServiceAPI.Domain.Interface;

namespace ECommerce.ProductServiceAPI.Ioc;

public static class ValidationDependencyInjection
{
    public static void AddValidationDependencyInjection(this IServiceCollection service)
    {
        service.AddScoped<IValidate<Product>, ProductValidation>();
        service.AddScoped<IValidate<ProductType>, ProductTypeValidation>();
    }
}
