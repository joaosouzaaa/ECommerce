using ECommerce.ProductServiceAPI.ApplicationService.DTOs.Request.ProductTypeRequest;
using ECommerce.ProductServiceAPI.Domain.Handlers.Notification;
using ECommerce.ProductServiceAPI.Domain.Interface.ServiceContract;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.ProductServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeController : ControllerBase
    {
        private readonly IProductTypeService _productTypeService;

        public ProductTypeController(IProductTypeService productTypeService)
        {
            _productTypeService = productTypeService;
        }

        [HttpPost("producttype_save")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
        public async Task<bool> Post(ProductTypeSaveRequest saveRequest) =>
            await _productTypeService.SaveAsync(saveRequest);

        [HttpPut("producttype_update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
        public async Task<bool> Put(ProductTypeUpdateRequest updateRequest) =>
            await _productTypeService.UpdateAsync(updateRequest);

        [HttpDelete("producttype_delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
        public async Task<bool> Delete(int productTypeId) =>
            await _productTypeService.DeleteAsync(productTypeId);
    }
}
