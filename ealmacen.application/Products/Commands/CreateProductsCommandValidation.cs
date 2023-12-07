using FluentValidation;

namespace eAlmacen.Application.Products.Commands;

public class CreateProductsCommandValidator : AbstractValidator<CreateProductsCommand>
{
    public CreateProductsCommandValidator()
    {
        RuleFor(p => p.Name).NotEmpty();
    }
}