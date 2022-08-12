using ECommerce.CouponServiceAPI.Domain.Entities;
using ECommerce.CouponServiceAPI.Domain.Enum;
using ECommerce.CouponServiceAPI.Domain.Extensions;
using FluentValidation;

namespace ECommerce.CouponServiceAPI.Domain.Handlers.Validation.ValidationEntities;

public class CouponValidation : Validate<Coupon>
{
    public CouponValidation()
    {
        SetRules();
    }

    private void SetRules()
    {
        RuleFor(pt => pt.CouponCode).Length(11).Must(pt => !pt.All(pt => char.IsWhiteSpace(pt)))
           .WithMessage(p => string.IsNullOrWhiteSpace(p.CouponCode)
           ? EMessage.Required.Description().FormatTo("Coupon code")
           : EMessage.MoreExpected.Description().FormatTo("Coupon code", "{Minlength} a {MaxLength}"));

        RuleFor(pt => pt.DiscountAmount).GreaterThan(0)
            .WithMessage(EMessage.ValueExpected.Description().FormatTo("Discount amount", "0.00"));
    }
}
