using ECommerce.ProductServiceAPI.ApplicationService.DTOs.Request.ProductRequest;
using ECommerce.ProductServiceAPI.ApplicationService.DTOs.Response.ProductResponse;
using ECommerce.ProductServiceAPI.Domain.Handlers.Notification;
using ECommerce.ProductServiceAPI.Domain.Handlers.Pagination;
using ECommerce.ProductServiceAPI.Domain.Interface.ServiceContract;
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

    [HttpDelete("delete_product")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType (StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
    public async Task<bool> DeleteAsync(int productId) =>
        await _productService.DeleteAsync(productId);


    [HttpGet("findby_product")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
    public async Task<ProductSearchResponse> FindByAsync(int productId) =>
        await _productService.FindByAsync(productId);

    [HttpGet("find_pagination_product")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
    public async Task<PageList<ProductSearchResponse>> FindByWithPaginationAsync(PageParams pageParams) =>
        await _productService.FindByWithPagination(pageParams);
}
