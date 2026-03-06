using Carter;
using MediatR;

namespace Basket.API.Basket.StoreBasket
{
    public class StoreBasketEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/Basket/Store", async (StoreBasketCommand command, ISender sender) =>
            {
                var response = await sender.Send(command);
                return Results.Created($"/Basket/{response.Username}", response);
            }).WithName("CreateBasket")
            .Produces<StoreBasketResult>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest) 
            .WithSummary("Create Basket")
            .WithDescription("Create Basket");
        }
    }
}
