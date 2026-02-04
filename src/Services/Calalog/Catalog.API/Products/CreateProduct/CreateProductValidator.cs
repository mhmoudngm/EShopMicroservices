
using FluentValidation;

namespace Catalog.API.Product.CreateProduct
{
    public class CreateProductValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage("name is required");
            RuleFor(p => p.Description)
                .NotEmpty()
                .WithMessage("description is required");
            RuleFor(i => i.Price)
                .NotEmpty()
                .WithMessage("price is required");
        }
    }
}
