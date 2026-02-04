namespace Catalog.API.Products.DeleteProduct
{
    public class DeleteProductCommand:IRequest<DeleteProductResult>
    {
        public Guid Id { get; set; }
    }
}
