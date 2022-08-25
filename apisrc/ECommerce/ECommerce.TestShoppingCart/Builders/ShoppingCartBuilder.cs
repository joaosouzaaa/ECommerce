using ECommerce.ShoppingCartServiceAPI.ApplicationService.Request;
using ECommerce.ShoppingCartServiceAPI.ApplicationService.Response;
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

        public ShoppingCartDatail DomainBuilder()
        {
            var productList = new List<Product>();
            productList.Add(ProductBuilder.NewObject().DomainBuilder());

            return new ShoppingCartDatail
            {
                Id = Guid.NewGuid().ToString(),
                TotalItens = _totalItens,
                TotalPrice = _totalPrice,
                Product = productList
            };
        }

        public ShoppingCartSaveRequest SaveRequestBuilder()
        {
            var productSaveRequestList = new List<ProductSaveRequest>();
            productSaveRequestList.Add(ProductBuilder.NewObject().SaveRequestBuilder());

            return new ShoppingCartSaveRequest
            {
                ProductsSaveRequest = productSaveRequestList
            };
        }

        public ShoppingCartResponse ResponseBuilder()
        {
            var productResponseList = new List<ProductResponse>();
            productResponseList.Add(ProductBuilder.NewObject().ResponseBuilder());

            return new ShoppingCartResponse
            {
                Id = Guid.NewGuid().ToString(),
                ProductsResponse = productResponseList,
                TotalItens = _totalItens,
                TotalPrice = _totalPrice
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
