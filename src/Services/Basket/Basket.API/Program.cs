using Basket.API.Data;
using Basket.API.Exceptions;
using Basket.API.Models;
using BuildingBlocks.Behaviors;
using Carter;
using FluentValidation;
using Marten;

var builder = WebApplication.CreateBuilder(args);

//add service to container (DI)
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
});
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
builder.Services.AddScoped<GlobalExceptionMiddleware>();
builder.Services.AddMarten(option =>
{
    option.Connection(builder.Configuration.GetConnectionString("Database")!);
    option.Schema.For<ShoppingCard>().Identity(x => x.UserName);//to set identity column
}).UseLightweightSessions();
builder.Services.AddScoped<IBasketRepository, BasketRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//configure the http request pipline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<GlobalExceptionMiddleware>();
app.MapCarter();
app.Run();
