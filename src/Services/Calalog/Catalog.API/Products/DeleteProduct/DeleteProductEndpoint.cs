
using Catalog.API.Products.UpdateProduct;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Products.DeleteProduct
{
    public class DeleteProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/products/Delete/{id}", async ([FromRoute]Guid id,ISender sender) =>
            {
                var result = await sender.Send(new DeleteProductCommand() { Id=id});

                return Results.Ok(result);
            }).WithName("DeleteProduct")
            .Produces<DeleteProductResult>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Delete Product")
            .WithDescription("Delete Product");
        }
    }
}
