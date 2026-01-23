namespace Catalog.API.Products.GetProductBycategory
{
    public class GetProductByCategoryQuery:IRequest<GetProductByCategoryResult>
    {
        public required string Category { get; set; }
    }
}
