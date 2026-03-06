using Basket.API.Basket.StoreBasket;
using Carter;
using MediatR;

namespace Basket.API.Basket.DeleteBasket
{
    public class DeleteBasketEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/Basket/{username}",async(string username,ISender sender)=>
            {
                var response = await sender.Send(new DeleteBasketCommand() { Username = username });
                return Results.Ok(response);
            }).WithName("DeleteBasket")
            .Produces<DeleteBasketResult>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Delete Basket")
            .WithDescription("Delete Basket");
        }

    }
}
