using ECommerce.ProductServiceAPI.Domain.Entities;
using ECommerce.ProductServiceAPI.Domain.Enum;
using ECommerce.ProductServiceAPI.Domain.Extensions;
using FluentValidation;

namespace ECommerce.ProductServiceAPI.Domain.Handlers.Validation.ValidationEntities;

public class ProductValidation : Validate<Product>
{
    public ProductValidation()
    {
        SetRules();
    }

    private void SetRules()
    {
        RuleFor(p => p.ProductType).SetValidator(new ProductTypeValidation());


        RuleFor(p => p.Name).Length(2, 50).Must(p => !p.All(p => char.IsWhiteSpace(p)))
            .WithMessage(p => string.IsNullOrWhiteSpace(p.Name)
            ? EMessage.Required.Description().FormatTo("Name")
            : EMessage.MoreExpected.Description().FormatTo("Name", "{MinLength} a {MaxLength}"));

        RuleFor(p => p.Description).Length(2, 500).Must(p => !p.All(p => char.IsWhiteSpace(p)))
            .WithMessage(p => string.IsNullOrWhiteSpace(p.Description)
            ? EMessage.Required.Description().FormatTo("Description")
            : EMessage.MoreExpected.Description().FormatTo("Description", "{Minlength} a {Maxlength}"));

        RuleFor(p => p.Price).GreaterThan(0)
            .WithMessage(EMessage.ValueExpected.Description().FormatTo("Price", "0.00"));

        When(p => !string.IsNullOrWhiteSpace(p.OtherDetails), () =>
        {
            RuleFor(p => p.OtherDetails).Length(2, 900).Must(p => !p.All(p => char.IsWhiteSpace(p)))
                .WithMessage(p => string.IsNullOrWhiteSpace(p.OtherDetails)
                ? EMessage.Required.Description().FormatTo("Details")
                : EMessage.MoreExpected.Description().FormatTo("Details", "{MinLength} a {MaxLength}"));

        });
    }
}
