using ECommerce.ShoppingCartServiceAPI.Domain.Entities;
using ECommerce.ShoppingCartServiceAPI.Domain.Enum;
using ECommerce.ShoppingCartServiceAPI.Domain.Extensions;
using FluentValidation;

namespace ECommerce.ShoppingCartServiceAPI.Domain.Handlers.Validation.EntitiesValidation;

public class CardPaymentValidation : Validate<CardPayment>
{
    public CardPaymentValidation()
    {
        SetRules();
    }

    private void SetRules()
    {
        RuleFor(c => c.CardNumber).Length(16)
            .Must(c => !c.All(c => char.IsWhiteSpace(c)))
            .WithMessage(c => string.IsNullOrWhiteSpace(c.CardNumber)
            ? EMessage.Required.Description().FormatTo("CardNumber")
            : EMessage.MoreExpected.Description().FormatTo("CardNumber", "{MaxLength}"));

        RuleFor(c => c.CVV).Length(3)
            .Must(c => !c.All(c => char.IsWhiteSpace(c)))
            .WithMessage(c => string.IsNullOrWhiteSpace(c.CVV)
            ? EMessage.Required.Description().FormatTo("CVV")
            : EMessage.MoreExpected.Description().FormatTo("CVV", "{MaxLength}"));


        RuleFor(c => c.ExpiryMonthYear).Length(10)
            .Must(c => !c.All(c => char.IsWhiteSpace(c)))
            .WithMessage(c => string.IsNullOrWhiteSpace(c.ExpiryMonthYear)
            ? EMessage.Required.Description().FormatTo("ExpiryMonthYear")
            : EMessage.MoreExpected.Description().FormatTo("ExpiryMonthYear", "{MaxLength}"));
    }
}
