using ECommerce.ShoppingCartServiceAPI.ApplicationService.DTOs.Request.ValueObjectRequest;
using ECommerce.ShoppingCartServiceAPI.ApplicationService.Request;
using ECommerce.ShoppingCartServiceAPI.ApplicationService.Request.MessageRequest;
using ECommerce.ShoppingCartServiceAPI.ApplicationService.Response;
using ECommerce.ShoppingCartServiceAPI.ApplicationService.Service.Base;
using ECommerce.ShoppingCartServiceAPI.Domain.Entities;
using ECommerce.ShoppingCartServiceAPI.Domain.Enum;
using ECommerce.ShoppingCartServiceAPI.Domain.Extensions;
using ECommerce.ShoppingCartServiceAPI.Domain.Handlers.Notification;
using ECommerce.ShoppingCartServiceAPI.Domain.Interface;
using ECommerce.ShoppingCartServiceAPI.Domain.Interface.RepositoryContract;
using ECommerce.ShoppingCartServiceAPI.Domain.Interface.ServiceContract;
using ECommerce.ShoppingCartServiceAPI.RabbitMQSender;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.ShoppingCartServiceAPI.ApplicationService.Service;

public class ShoppingCartService : BaseService<ShoppingCartHeader>, IShoppingCartService
{
    private readonly IShoppingCartRepository _shoppingCartRepository;
    private readonly IRabbitMQMessageSender _rabbitMQ;
    private const string _QUEUE = "ShoppingCartQueue";

    public ShoppingCartService(IValidate<ShoppingCartHeader> validate, 
                               INotificationHandler notification,
                               IShoppingCartRepository shoppingCartRepository,
                               IRabbitMQMessageSender rabbitMQMessage) 
        : base(validate, notification)
    {
        _shoppingCartRepository = shoppingCartRepository;
        _rabbitMQ = rabbitMQMessage;
    }


    public async Task<ShoppingCartResponse> GetShoppingCartAsync(int shoppingCartId)
    {
        var shoppingCart = await _shoppingCartRepository.FindByAsync(shoppingCartId, i => i
            .Include(sc => sc.Products));

        var response = shoppingCart.MapTo<ShoppingCartHeader, ShoppingCartResponse>();

        CalculateProductAndQuantities(shoppingCart, response);

        return response;
    }

    public async Task<bool> FinalizePurchase(FinalizePurchaseRequest finalizePurchaseRequest)
    {
        var shoppingCart = await _shoppingCartRepository.FindByAsync(finalizePurchaseRequest.ShoppingCartId, i => i
            .Include(s => s.Products)
            .Include(s => s.CardPayment)
            .Include(s => s.Customer));

        shoppingCart.Customer = finalizePurchaseRequest.Customer.MapTo<CustomerVORequest, Customer>();
        shoppingCart.CardPayment = finalizePurchaseRequest.CardPayment.MapTo<CardPaymentVORequest, CardPayment>();

        if (!await ValidationAsync(shoppingCart))
            return false;

        var CheckoutMessage = shoppingCart.MapTo<ShoppingCartHeader, CheckoutHeaderRequest>();
         _rabbitMQ.SendMessage(CheckoutMessage, _QUEUE);

        return await _shoppingCartRepository.UpdateAsync(shoppingCart);
    }

    public async Task<bool> AddCoupoum(int shoppingCartId, string CouponCode)
    {
        var shoppingCart = await _shoppingCartRepository.FindByAsync(shoppingCartId, i => i
             .Include(sc => sc.Products));

        shoppingCart.CouponCode = CouponCode;

        if (!await ValidationAsync(shoppingCart))
            return false;

        return await _shoppingCartRepository.UpdateAsync(shoppingCart);
    }

    public async Task<bool> AddProductAsync(int shoppingCartId, ProductSaveRequest saveProduct)
    {
        var shoppingCart = await _shoppingCartRepository.FindByAsync(shoppingCartId, i => i
            .Include(sc => sc.Products));

        if (shoppingCart == null)
            return _notification.AddNotification(new DomainNotification("ShoppingCart", EMessage.NotFound.Description().FormatTo("Carrinho de Compras")));

        if (IncreaseProductQuantity(saveProduct, shoppingCart))
            return await _shoppingCartRepository.UpdateAsync(shoppingCart);
        else
        {
            var product = saveProduct.MapTo<ProductSaveRequest, Product>();
            shoppingCart.Products.Add(product);

            return await _shoppingCartRepository.UpdateAsync(shoppingCart);
        }
    }

    public async Task<bool> RemoveProductAsync(int shoppingCartId, ProductSaveRequest productRequest)
    {
        var shoppingCart = await _shoppingCartRepository.FindByAsync(shoppingCartId, i => i
            .Include(sc => sc.Products));

        if (shoppingCart.Products.Any(p => p.Id == productRequest.ProductId))
        {
            var product = productRequest.MapTo<ProductSaveRequest, Product>();
            shoppingCart.Products.Remove(product);

            return await _shoppingCartRepository.UpdateAsync(shoppingCart);
        }

        return false;
    }

    private void CalculateProductAndQuantities(ShoppingCartHeader shoppingCart, ShoppingCartResponse response)
    {
        response.TotalItens = shoppingCart.Products.Count();

        foreach (var product in shoppingCart.Products)
        {
            response.TotalPrice += product.Price;
        }
    }

    private bool IncreaseProductQuantity(ProductSaveRequest saveProduct, ShoppingCartHeader shoppingCart)
    {
        if (shoppingCart.Products.Any(p => p.Id == saveProduct.ProductId))
        {
            var product = shoppingCart.Products.Find(p => p.Id == saveProduct.ProductId);
            product.Amount += saveProduct.Amount;

            return true;
        }

        return false;
    }
}
