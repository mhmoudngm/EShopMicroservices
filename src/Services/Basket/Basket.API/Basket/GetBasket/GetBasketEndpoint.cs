using Carter;
using MediatR;

namespace Basket.API.Basket.GetBasket
{
    public class GetBasketEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/Basket/{username}", async (string username, ISender sender) =>
            {
                var result = await sender.Send(new GetBasketQuery() { Username = username });
                return Results.Ok(result);
            }).WithName("GetBasket")
            .Produces<GetBasketResult>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Basket")
            .WithDescription("Get Basket");
        }
    }
}
