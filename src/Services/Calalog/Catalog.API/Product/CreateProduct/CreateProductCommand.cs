using MediatR;

namespace Catalog.API.Product.CreateProduct
{
    public class CreateProductCommand : IRequest<CreateProductResult>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Imagefile { get; set; } = default!;
        public decimal Price { get; set; }
        public List<string> Category { get; set; } = new();
    }
}
