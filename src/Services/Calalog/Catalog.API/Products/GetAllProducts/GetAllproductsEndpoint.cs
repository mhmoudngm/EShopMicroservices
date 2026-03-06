
using Catalog.API.Products.GetProduct;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Products.GetAllProducts
{
    public class GetAllproductsEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/GetAllProducts", async ([AsParameters] GetAllProductsQuery query, ISender sender) =>
            {
                var result = await sender.Send(query);
                return Results.Ok(result);
            }).WithName("GetAllProducts")
             .Produces<GetAllProductsResult>(StatusCodes.Status200OK)
             .ProducesProblem(StatusCodes.Status404NotFound)
             .WithSummary("Get All Products")
             .WithDescription("Get All Products");
        }
    }
}
