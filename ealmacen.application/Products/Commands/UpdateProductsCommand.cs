using AutoMapper;
using eAlmacen.Domain.Exceptions;
using eAlmacen.persistence.Interfaces;
using MediatR;

namespace eAlmacen.Application.Products.Commands;

public class UpdateProductsCommand : IRequest<Unit>
{
    public int Id { get; set; }

    public class UpdateProductsCommandHandler : IRequestHandler<UpdateProductsCommand, Unit>
    {
        private readonly IApplicationDbContext _dbContext;

        private readonly IMapper _mapper;

        public UpdateProductsCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateProductsCommand request, CancellationToken cancellationToken)
        {
            var _Products = _dbContext.Products.FirstOrDefault(e => e.Id == request.Id) ?? throw new NotFoundException(nameof(Products), request.Id);

            var updatedProducts = _mapper.Map(request, _Products);

            _dbContext.Products.Update(updatedProducts);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}