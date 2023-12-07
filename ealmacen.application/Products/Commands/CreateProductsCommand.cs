using eAlmacen.Domain.Entities;
using MediatR;

namespace eAlmacen.Application.Products.Commands;

public class CreateProductsCommand : IRequest<Product>
{
    public string Name { get; set; }
}