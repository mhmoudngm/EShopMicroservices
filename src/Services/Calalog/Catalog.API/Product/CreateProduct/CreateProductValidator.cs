using FluentValidation;

namespace Catalog.API.Product.CreateProduct
{
    public class CreateProductValidator:AbstractValidator<CreateProductCommand>
    {
        public CreateProductValidator()
        {
            RuleFor(i=>i.Price).NotEmpty(); 
        }
    }
}
