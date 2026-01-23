using FluentValidation;

namespace Catalog.API.Products.GetProduct
{
    public class GetProductValidator:AbstractValidator<GetProductQuery>
    {
        public GetProductValidator()
        {
            RuleFor(i=>i.Id)
                .NotEmpty()
                .NotNull()
                .WithMessage("this failed required");

        }
    }
}
