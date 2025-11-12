public class CreateProductrequest
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Imagefile { get; set; } = default!;
    public decimal Price { get; set; }
    public List<string> Category { get; set; } = new();
}
namespace Catalog.API.Product.CreateProduct
{
    public class CreateProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/products", async (CreateProductrequest CreateProductmodel, ISender sender) =>
            {
                var command = CreateProductmodel.Adapt<CreateProductCommand>();
                var result = await sender.Send(command);
                var response = result.Adapt<CreateProductResult>();

                return Results.Created($"/products/{response.Id}", response);
            }).WithName("CreateProduct")
            .Produces<CreateProductResult>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Create Product")
            .WithDescription("Create Product");
        }
    }
}
