using Catalog.API.Models;

namespace Catalog.API.Products.GetProductBycategory
{
    public class GetProductByCategoryResult
    {
        public IEnumerable<Catalog.API.Models.Product> Products { get; set; }
    }
}
