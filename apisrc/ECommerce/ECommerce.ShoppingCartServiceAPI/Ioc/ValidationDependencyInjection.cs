using ECommerce.ShoppingCartServiceAPI.Domain.Entities;
using ECommerce.ShoppingCartServiceAPI.Domain.Handlers.Validation.EntitiesValidation;
using ECommerce.ShoppingCartServiceAPI.Domain.Interface;

namespace ECommerce.ShoppingCartServiceAPI.Ioc;

public static class ValidationDependencyInjection
{
    public static void AddValidationDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IValidate<ShoppingCart>, ShoppingCartValidation>();
        services.AddScoped<IValidate<Product>, ProductValidation>();
    }
}
