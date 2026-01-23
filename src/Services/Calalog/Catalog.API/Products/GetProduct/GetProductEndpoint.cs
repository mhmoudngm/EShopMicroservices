
using Catalog.API.Product.CreateProduct;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Products.GetProduct
{
    public class GetProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/GetProduct/{id}", async (ISender sender, [FromRoute] Guid id) =>
            {
                var result = await sender.Send(new GetProductQuery() { Id=id});
                return Results.Ok(result);
            }).WithName("GetProduct")
            .Produces<GetProductResult>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Get Product")
            .WithDescription("Get Product");
        }
    }
}
