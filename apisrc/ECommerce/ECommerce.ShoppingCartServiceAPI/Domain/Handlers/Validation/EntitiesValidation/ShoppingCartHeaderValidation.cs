using ECommerce.ShoppingCartServiceAPI.Domain.Entities;
using ECommerce.ShoppingCartServiceAPI.Domain.Enum;
using ECommerce.ShoppingCartServiceAPI.Domain.Extensions;
using ECommerce.ShoppingCartServiceAPI.Domain.Handlers.Validation.ValidationEntities;
using FluentValidation;

namespace ECommerce.ShoppingCartServiceAPI.Domain.Handlers.Validation.EntitiesValidation;

public class ShoppingCartHeaderValidation : Validate<ShoppingCartHeader>
{
    public ShoppingCartHeaderValidation()
    {
        SetRules();
    }

    private void SetRules()
    {
        RuleFor(sc => sc.Customer).SetValidator(new CustomerValidation());
        RuleFor(sc => sc.CardPayment).SetValidator(new CardPaymentValidation());
        RuleForEach(sc => sc.Products).SetValidator(new ProductValidation());

        When(sc => string.IsNullOrWhiteSpace(sc.CouponCode), () =>
        {
            RuleFor(p => p.CouponCode).Length(11).Must(p => !p.All(p => char.IsWhiteSpace(p)))
                .WithMessage(p => string.IsNullOrWhiteSpace(p.CouponCode)
                ? EMessage.Required.Description().FormatTo("CouponCode")
                : EMessage.MoreExpected.Description().FormatTo("CouponCode", "{MaxLength}"));
        });

        RuleFor(p => p.PurchaseAmount).GreaterThan(0)
                .WithMessage(EMessage.ValueExpected.Description().FormatTo("PurchaseAmount", "{PropertyValue}"));

        RuleFor(p => p.DiscountAmount).GreaterThan(0)
               .WithMessage(EMessage.ValueExpected.Description().FormatTo("DiscountAmount", "{PropertyValue}"));

        RuleFor(p => p.CartTotalItens).GreaterThan(0)
              .WithMessage(EMessage.ValueExpected.Description().FormatTo("CartTotalItens", "{PropertyValue}"));
    }
}
