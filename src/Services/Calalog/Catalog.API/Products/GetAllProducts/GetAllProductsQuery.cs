namespace Catalog.API.Products.GetAllProducts
{
    public class GetAllProductsQuery : IRequest<GetAllProductsResult>
    {
        public int? PageNumber { get; set; } = 1;
        public int? PageSize { get; set; } = 10;
    }
}
