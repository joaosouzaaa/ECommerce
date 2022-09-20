using ECommerce.ShoppingCartServiceAPI.Domain.Entities;
using ECommerce.ShoppingCartServiceAPI.Domain.Handlers.Validation.EntitiesValidation;
using ECommerce.ShoppingCartServiceAPI.Domain.Handlers.Validation.ValidationEntities;
using ECommerce.ShoppingCartServiceAPI.Domain.Interface;

namespace ECommerce.ShoppingCartServiceAPI.Ioc;

public static class ValidationDependencyInjection
{
    public static void AddValidationDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IValidate<Product>, ProductValidation>();
        services.AddScoped<IValidate<Customer>, CustomerValidation>();
        services.AddScoped<IValidate<ProductType>, ProductTypeValidation>();
        services.AddScoped<IValidate<ProductType>, ProductTypeValidation>();
        services.AddScoped<IValidate<ShoppingCartHeader>, ShoppingCartHeaderValidation>();
        services.AddScoped<IValidate<ShoppingCartHeader>, ShoppingCartHeaderValidation>();
        services.AddScoped<IValidate<CardPayment>, CardPaymentValidation>();
    }
}
