
using Catalog.API.Product.CreateProduct;

namespace Catalog.API.Products.UpdateProduct
{
    public class UpdateProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/products/Update", async (UpdateProductCommand command, ISender sender) =>
            {
                var result = await sender.Send(command);

                return Results.Ok(result);
            }).WithName("UpdateProduct")
            .Produces<UpdateProductResult>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Update Product")
            .WithDescription("Update Product");

        }
    }
}
