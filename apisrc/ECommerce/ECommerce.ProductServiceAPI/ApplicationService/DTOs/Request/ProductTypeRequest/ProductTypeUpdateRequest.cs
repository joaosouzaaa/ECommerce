using ECommerce.MessageBus.Entities;
using ECommerce.ProductServiceAPI.Domain.Enum;

namespace ECommerce.ProductServiceAPI.ApplicationService.DTOs.Request.ProductTypeRequest;

public class ProductTypeUpdateRequest : BaseMessage
{
    public int ProductTypeId { get; set; }
    public string Name { get; set; }
    public ECategory Category { get; set; }
}
