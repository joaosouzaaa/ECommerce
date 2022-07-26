using ECommerce.ShoppingCartServiceAPI.Domain.Entities;
using ECommerce.ShoppingCartServiceAPI.Domain.Enum;
using ECommerce.ShoppingCartServiceAPI.Domain.Extensions;
using FluentValidation;

namespace ECommerce.ShoppingCartServiceAPI.Domain.Handlers.Validation.EntitiesValidation
{
    public class ShoppingCartValidation : Validate<ShoppingCart>
    {
        public ShoppingCartValidation()
        {
            SetRules();
        }

        private void SetRules()
        {
            RuleForEach(sc => sc.Products).SetValidator(new ProductValidation());

            When(sc => sc.TotalItens > 0, () =>
            {
                RuleFor(sc => sc.TotalPrice).GreaterThan(0)
                    .WithMessage(EMessage.ValueExpected.Description().FormatTo("Valor", "0,00"));
            });
        }
    }
    
}
