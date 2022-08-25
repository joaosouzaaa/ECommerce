//using ECommerce.ShoppingCartServiceAPI.ApplicationService.Request;
//using ECommerce.ShoppingCartServiceAPI.ApplicationService.Response;
//using ECommerce.ShoppingCartServiceAPI.ApplicationService.Service.Base;
//using ECommerce.ShoppingCartServiceAPI.Domain.Entities;
//using ECommerce.ShoppingCartServiceAPI.Domain.Enum;
//using ECommerce.ShoppingCartServiceAPI.Domain.Extensions;
//using ECommerce.ShoppingCartServiceAPI.Domain.Handlers.Notification;
//using ECommerce.ShoppingCartServiceAPI.Domain.Interface;
//using ECommerce.ShoppingCartServiceAPI.Domain.Interface.RepositoryContract;
//using ECommerce.ShoppingCartServiceAPI.Domain.Interface.ServiceContract;
//using ECommerce.ShoppingCartServiceAPI.RabbitMQSender;

//namespace ECommerce.ShoppingCartServiceAPI.ApplicationService.Service;

//public class ShoppingCartService : BaseService<ShoppingCartDatail>, IShoppingCartService
//{
//    private readonly IShoppingCartRepository _shoppingCartRepository;
//    private readonly IRabbitMQMessageSender _rabbitMQ;
//    private const string _queue = "ShoppingCartQueue";

//    public ShoppingCartService(IShoppingCartRepository shoppingCartRepository,
//                               IValidate<ShoppingCartDatail> validate,
//                               INotificationHandler notification,
//                               IRabbitMQMessageSender rabbitMQ)
//            : base(validate, notification)
//    {
//        _shoppingCartRepository = shoppingCartRepository;
//        _rabbitMQ = rabbitMQ;
//    }

//    public async Task<bool> SetAsync(ShoppingCartSaveRequest saveRequest)
//    {
//        var shoppingCart = saveRequest.MapTo<ShoppingCartSaveRequest, ShoppingCartDatail>();
//        shoppingCart.TotalItens = saveRequest.ProductsSaveRequest.Count;
//        shoppingCart.TotalPrice = 0;
//        foreach (var product in saveRequest.ProductsSaveRequest)
//            shoppingCart.TotalPrice += product.Price;

//        if (!await ValidationAsync(shoppingCart))
//            return false;

//        _rabbitMQ.SendMessage(saveRequest, _queue);
        
//        await _shoppingCartRepository.SetAsync(shoppingCart);

//        return true;
//    }

//    public async Task<ShoppingCartResponse> GetAsync(string key)
//    {
//        var shoppingCart = await _shoppingCartRepository.GetAsync(key);

//        if (shoppingCart != null)
//            return shoppingCart.MapTo<ShoppingCartDatail, ShoppingCartResponse>();

//        return null;
//    }

//    public async Task<bool> RemoveAsync(string key)
//    {
//        var getString = await _shoppingCartRepository.GetStringAsync(key);
//        if (getString != null)
//        {
//            await _shoppingCartRepository.RemoveAsync(key);
//            return true;
//        }

//        return _notification.AddNotification(new DomainNotification("ShoppingCart", EMessage.NotFound.Description().FormatTo("Shopping Cart")));
//    }

//    public async Task<bool> RefreshAsync(string key)
//    {
//        var getString = await _shoppingCartRepository.GetStringAsync(key);
//        if (getString != null)
//        {
//            await _shoppingCartRepository.RefreshAsync(key);
//            return true;
//        }

//        return _notification.AddNotification(new DomainNotification("ShoppingCart", EMessage.NotFound.Description().FormatTo("Shopping Cart")));
//    }
//}
