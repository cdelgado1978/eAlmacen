using AutoMapper;
using eAlmacen.Application.Products.Responses;
using eAlmacen.Domain.Entities;
using eAlmacen.Domain.Exceptions;
using eAlmacen.Domain.Interfaces;
using MediatR;

namespace eAlmacen.Application.Products.Queries;

public class GetProductsQueryById : IRequest<ProductsResponseModel>
{
    public int Id { get; set; }

    public class GetProductsQueryByIdHandler(IApplicationDbContext dbContext, IMapper mapper) : IRequestHandler<GetProductsQueryById, ProductsResponseModel>
    {
        public async Task<ProductsResponseModel> Handle(GetProductsQueryById request, CancellationToken cancellationToken)
        {
            Product entity = dbContext.Products.FirstOrDefault(e => e.Id == request.Id) ?? throw new NotFoundException(nameof(Products), request.Id);

            return await Task.FromResult(mapper.Map<ProductsResponseModel>(entity));
        }
    }
}