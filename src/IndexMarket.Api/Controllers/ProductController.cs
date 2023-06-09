﻿using IndexMarket.Application.DataTransferObject;
using IndexMarket.Application.Paginations;
using IndexMarket.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IndexMarket.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductServices productServices;
    public ProductController(
        IProductServices productServices)
    {
        this.productServices = productServices;
    }

    [HttpPost]
    public async ValueTask<ActionResult<ProductDto>> PostProductAsync(
        ProductForCreationDto productForCreationDto)
    {
        var product = await this.productServices.CreateProductAsync(productForCreationDto);

        return Created("", product);
    }

    [HttpPost("rectangel")]
    public async ValueTask<ActionResult<ProductDto>> PostProductRectangelAsync(
        ProductForCreationDtoRectangel productForCreationDtoRectangel)
    {
        var product = await this.productServices.CreateRectangelProductAsync(productForCreationDtoRectangel);

        return Created("", product); 
    }

    [HttpGet("all")]
    public IActionResult GetAllProducts(
        [FromQuery] QueryParametrs queryParametrs)
    {
        var products = this.productServices.RetrieveProducts(queryParametrs);

        return Ok(products);
    }

    [HttpGet("{productId:guid}")]
    public async ValueTask<ActionResult<ProductDto>> GetProductByIdAsync(Guid productId)
    {
        var product = await this.productServices.RetrieveProductByIdAsync(productId);

        return Ok(product);
    }

    [HttpPut]
    public async ValueTask<ActionResult<ProductDto>> PutProductAsync(
        ProductForModificationDto productForModificationDto)
    {
        var modifyProduct = await this.productServices.ModifyProductAsync(productForModificationDto);

        return Ok(modifyProduct);
    }

    [HttpDelete("{productId:guid}")]
    public async ValueTask<ActionResult<ProductDto>> DeleteProductAsync(Guid productId)
    {
        var removeProduct = await this.productServices.RemoveProductAsync(productId);

        return Ok(removeProduct);
    }
}
