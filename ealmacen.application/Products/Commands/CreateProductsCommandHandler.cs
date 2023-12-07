using AutoMapper;
using eAlmacen.Domain.Entities;
using eAlmacen.persistence.Interfaces;
using MediatR;

namespace eAlmacen.Application.Products.Commands;

public class CreateProductsCommandHandler(IApplicationDbContext dbContext, IMapper mapper) : IRequestHandler<CreateProductsCommand, Product>
{
    public async Task<Product> Handle(CreateProductsCommand request, CancellationToken cancellationToken)
    {
        var newProducts = mapper.Map<Product>(request);

        dbContext.Products.Add(newProducts);

        await dbContext.SaveChangesAsync(cancellationToken);

        return newProducts;
    }
}