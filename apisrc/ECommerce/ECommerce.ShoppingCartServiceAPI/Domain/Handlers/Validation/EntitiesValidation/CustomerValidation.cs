using ECommerce.ShoppingCartServiceAPI.Domain.Entities;
using ECommerce.ShoppingCartServiceAPI.Domain.Enum;
using ECommerce.ShoppingCartServiceAPI.Domain.Extensions;
using FluentValidation;

namespace ECommerce.ShoppingCartServiceAPI.Domain.Handlers.Validation.EntitiesValidation;

public class CustomerValidation : Validate<Customer>
{
    public CustomerValidation()
    {
        SetRules();
    }

    private void SetRules()
    {

        RuleFor(pt => pt.FisrtName).Length(3, 50).Must(pt => !pt.All(pt => char.IsWhiteSpace(pt)))
               .WithMessage(p => string.IsNullOrWhiteSpace(p.FisrtName)
               ? EMessage.Required.Description().FormatTo("FisrtName")
               : EMessage.MoreExpected.Description().FormatTo("FisrtName", "{Minlength} a {MaxLength}"));

        RuleFor(pt => pt.LastName).Length(3, 50).Must(pt => !pt.All(pt => char.IsWhiteSpace(pt)))
              .WithMessage(p => string.IsNullOrWhiteSpace(p.LastName)
              ? EMessage.Required.Description().FormatTo("LastName")
              : EMessage.MoreExpected.Description().FormatTo("LastName", "{Minlength} a {MaxLength}"));

        RuleFor(pt => pt.Phone).Length(9, 11).Must(pt => !pt.All(pt => char.IsWhiteSpace(pt)))
              .WithMessage(p => string.IsNullOrWhiteSpace(p.Phone)
              ? EMessage.Required.Description().FormatTo("Phone")
              : EMessage.MoreExpected.Description().FormatTo("Phone", "{Minlength} a {MaxLength}"));

        RuleFor(pt => pt.Email).EmailAddress()
             .WithMessage(EMessage.Required.Description().FormatTo("Email"));
    }
}
