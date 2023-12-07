using AutoMapper;
using eAlmacen.Application.Products.Responses;
using eAlmacen.Domain.Entities;
using eAlmacen.persistence.Interfaces;
using MediatR;

namespace eAlmacen.Application.Products.Queries;

public class GetProductsQuery : IRequest<List<ProductsResponseModel>>
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<ProductsResponseModel>>
    {
        private readonly IApplicationDbContext _dbContext;

        private readonly IMapper _mapper;

        public GetProductsQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<ProductsResponseModel>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            IQueryable<Product> entity = _dbContext.Products;

            return _mapper.Map<List<ProductsResponseModel>>(entity);
        }
    }
}