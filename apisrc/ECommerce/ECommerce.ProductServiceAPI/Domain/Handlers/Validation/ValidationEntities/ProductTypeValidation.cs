using ECommerce.ProductServiceAPI.Domain.Entities;
using ECommerce.ProductServiceAPI.Domain.Enum;
using ECommerce.ProductServiceAPI.Domain.Extensions;
using FluentValidation;

namespace ECommerce.ProductServiceAPI.Domain.Handlers.Validation.ValidationEntities;

public class ProductTypeValidation : Validate<ProductType>
{
    public ProductTypeValidation()
    {
        SetRules();
    }

    private void SetRules()
    {
        RuleFor(pt => pt.Name).Length(2, 50).Must(pt => !pt.All(pt => char.IsWhiteSpace(pt)))
           .WithMessage(p => string.IsNullOrWhiteSpace(p.Name)
           ? EMessage.Required.Description().FormatTo("Name")
           : EMessage.MoreExpected.Description().FormatTo("Name", "{Minlength} a {MaxLength}"));

        RuleFor(pt => pt.Category).NotNull()
            .WithMessage(EMessage.Required.Description().FormatTo("Category"));
    }
}
