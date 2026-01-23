namespace Catalog.API.Products.GetProduct
{
    public class GetProductQuery:IRequest<GetProductResult>
    {
        public Guid Id { get; set; }
    }
}
