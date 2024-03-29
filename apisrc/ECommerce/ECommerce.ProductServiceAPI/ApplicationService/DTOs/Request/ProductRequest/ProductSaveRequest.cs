﻿using ECommerce.MessageBus.Entities;
using ECommerce.ProductServiceAPI.ApplicationService.DTOs.Request.ProductTypeRequest;

namespace ECommerce.ProductServiceAPI.ApplicationService.DTOs.Request.ProductRequest;

public class ProductSaveRequest : BaseMessage
{
    public byte[]? Image { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string? OtherDetails { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }

    public ProductTypeSaveRequest ProductType { get; set; }
}
