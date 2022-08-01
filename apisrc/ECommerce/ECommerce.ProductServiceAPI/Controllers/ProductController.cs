using ECommerce.ProductServiceAPI.ApplicationService.DTOs.Request.ProductRequest;
using ECommerce.ProductServiceAPI.Domain.Handlers.Notification;
using ECommerce.ProductServiceAPI.Domain.Interface.ServiceContract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.ProductServiceAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpPost("save_product")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
    public async Task<bool> SaveAsync(ProductSaveRequest saveRequest) =>
        await _productService.SaveAsync(saveRequest);

    [HttpPut("update_product")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
    public async Task<bool> UpdateAsync(ProductUpdateRequest updateRequest) =>
        await _productService.UpdateAsync(updateRequest);
}
