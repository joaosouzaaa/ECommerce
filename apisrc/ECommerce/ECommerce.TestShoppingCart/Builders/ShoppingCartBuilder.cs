using ECommerce.ShoppingCartServiceAPI.Domain.Entities;

namespace ECommerce.TestShoppingCart.Builders
{
    public class ShoppingCartBuilder
    {
        private int _totalItens = 2;
        private decimal _totalPrice = 2500.76m;

        private List<ProductBuilder> Products = new List<ProductBuilder>();

        public static ShoppingCartBuilder NewObject()
        {
            return new ShoppingCartBuilder();
        }

        public ShoppingCart DomainBuilder()
        {
            return new ShoppingCart
            {
                TotalItens = this._totalItens,
                TotalPrice = this._totalPrice
            };
        }

        public ShoppingCartBuilder WithTotalItens(int totalItens)
        {
            _totalItens = totalItens;
            return this;
        }

        public ShoppingCartBuilder WithTotalPrice(decimal totalPrice)
        {
            _totalPrice = totalPrice;
            return this;
        }
    }
}
