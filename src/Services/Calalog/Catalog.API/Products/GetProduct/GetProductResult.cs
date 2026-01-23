namespace Catalog.API.Products.GetProduct
{
    public class GetProductResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Imagefile { get; set; }
        public decimal Price { get; set; }
        public List<string> Category { get; set; }
    }
}
