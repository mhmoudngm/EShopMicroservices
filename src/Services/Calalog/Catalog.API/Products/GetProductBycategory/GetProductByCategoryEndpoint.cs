
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Products.GetProductBycategory
{
    public class GetProductByCategoryEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/GetProductsByCategory/{category}", async ([FromRoute] string category, ISender sender) =>
            {
                var result = await sender.Send(new GetProductByCategoryQuery() { Category = category });
                return Results.Ok(result);
            }).WithName("GetProductsByCategory")
            .Produces<GetProductByCategoryResult>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithDescription("GetProductsByCategory")
            .WithSummary("GetProductsByCategory");
        }
    }
}
