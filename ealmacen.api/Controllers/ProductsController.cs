using eAlmacen.Application.Products.Commands;
using eAlmacen.Application.Products.Queries;
using eAlmacen.Application.Products.Responses;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eAlmacen.api.Controllers;

[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[Route("{SlugTenant}/[controller]")]
public class ProductsController(IMediator mediator)
{
    [HttpGet()]
    public async Task<List<ProductsResponseModel>> Get()
    {
        return await mediator.Send(new GetProductsQuery());
    }

    [HttpGet("GetProductById")]
    public async Task<ProductsResponseModel> GetProductById(int id)
    {
        return await mediator.Send(new GetProductsQueryById() { Id = id });
    }

    [HttpPost()]
    public async Task<IActionResult> Post(string name)
    {
        var product = await mediator.Send(new CreateProductsCommand { Name = name });

        return new CreatedAtActionResult(nameof(GetProductById),
                                            "Products",
                                            new { id = product.Id },
                                            product
                                            );
    }
}