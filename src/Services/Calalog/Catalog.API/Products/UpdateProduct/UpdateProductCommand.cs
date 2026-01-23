namespace Catalog.API.Products.UpdateProduct
{
    public class UpdateProductCommand:IRequest<UpdateProductResult>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Imagefile { get; set; } = default!;
        public decimal Price { get; set; }
        public List<string> Category { get; set; } = new();
    }
}
