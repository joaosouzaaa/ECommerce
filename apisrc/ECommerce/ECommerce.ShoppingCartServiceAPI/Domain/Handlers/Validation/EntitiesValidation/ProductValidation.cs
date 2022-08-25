using ECommerce.ShoppingCartServiceAPI.Domain.Entities;
using ECommerce.ShoppingCartServiceAPI.Domain.Enum;
using ECommerce.ShoppingCartServiceAPI.Domain.Extensions;
using FluentValidation;

namespace ECommerce.ShoppingCartServiceAPI.Domain.Handlers.Validation.ValidationEntities
{
    public class ProductValidation : Validate<Product>
    {
        public ProductValidation()
        {
            SetRules();
        }

        private void SetRules()
        {

            RuleFor(p => p.ProductType).SetValidator(new ProductTypeValidation());


            When(p => !string.IsNullOrWhiteSpace(p.OtherDetails), () =>
            {
                RuleFor(p => p.OtherDetails).Length(3, 250).Must(p => !p.All(p => char.IsWhiteSpace(p)))
                    .WithMessage(p => string.IsNullOrWhiteSpace(p.OtherDetails)
                    ? EMessage.Required.Description().FormatTo("Other details")
                    : EMessage.MoreExpected.Description().FormatTo("Other details", "{MinLength} a {MaxLength}"));
            });

            RuleFor(p => p.Name).Length(2, 50).Must(p => !p.All(p => char.IsWhiteSpace(p)))
                .WithMessage(p => string.IsNullOrWhiteSpace(p.Name)
                ? EMessage.Required.Description().FormatTo("Name")
                : EMessage.MoreExpected.Description().FormatTo("Name", "{MinLength} a {MaxLength}"));

            RuleFor(p => p.Description).Length(3, 150).Must(p => !p.All(p => char.IsWhiteSpace(p)))
               .WithMessage(p => string.IsNullOrWhiteSpace(p.Description)
               ? EMessage.Required.Description().FormatTo("Description")
               : EMessage.MoreExpected.Description().FormatTo("Description", "{MinLength} a {MaxLength}"));

            RuleFor(p => p.Amount).GreaterThan(0)
               .WithMessage(EMessage.Required.Description().FormatTo("Amount"));

            RuleFor(p => p.Price).GreaterThan(0)
              .WithMessage(EMessage.ValueExpected.Description().FormatTo("Price", "{PropertyValue}"));
        }
    }
}
