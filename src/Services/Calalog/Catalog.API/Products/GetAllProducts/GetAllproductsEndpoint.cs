
using Catalog.API.Products.GetProduct;

namespace Catalog.API.Products.GetAllProducts
{
    public class GetAllproductsEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/GetAllProducts", async (ISender sender) =>
            {
                var result = await sender.Send(new GetAllProductsQuery());
                return Results.Ok(result);
            }).WithName("GetAllProducts")
             .Produces<GetAllProductsResult>(StatusCodes.Status200OK)
             .ProducesProblem(StatusCodes.Status404NotFound)
             .WithSummary("Get All Products")
             .WithDescription("Get All Products");
        }
    }
}
