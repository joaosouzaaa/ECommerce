using ECommerce.ShoppingCartServiceAPI.Domain.Extensions;
using ECommerce.ShoppingCartServiceAPI.Domain.Interface;
using FluentValidation;
using FluentValidation.Results;

namespace ECommerce.ShoppingCartServiceAPI.Domain.Handlers.Validation;

public class Validate<TEntity> : AbstractValidator<TEntity>, IValidate<TEntity> where TEntity : class
{
    private ValidationResult _validationResult { get; set; }

    private void CreateResult(TEntity entity) => _validationResult = base.Validate(entity);
    private async Task CreateResultAsync(TEntity entity) => _validationResult = await base.ValidateAsync(entity);
    private Dictionary<string, string> GetErrors() => _validationResult.Errors.ToDictionary();



    public ValidationResponse Validation(TEntity entity)
    {
        CreateResult(entity);
        return ValidationResponse.CreateValidation(GetErrors());
    }

    public async Task<ValidationResponse> ValidationAsync(TEntity entity)
    {
        await CreateResultAsync(entity);
        return ValidationResponse.CreateValidation(GetErrors());
    }
}
