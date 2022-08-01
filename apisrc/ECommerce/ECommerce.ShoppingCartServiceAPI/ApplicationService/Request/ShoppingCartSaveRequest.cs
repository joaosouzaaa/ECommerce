using ECommerce.MessageBus.Entities;

namespace ECommerce.ShoppingCartServiceAPI.ApplicationService.Request
{
    public class ShoppingCartSaveRequest : BaseMessage
    {
        public List<ProductSaveRequest> ProductsSaveRequest { get; set; }
    }
}
