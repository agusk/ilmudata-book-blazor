using CalculatorApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapPost("/api/calculate/add", (Number numbers) =>
{
    numbers.Result = numbers.Number1 + numbers.Number2;
    return Results.Ok(numbers);
})
.WithName("AddNumbers");

app.MapPost("/api/calculate/subtract", (Number numbers) =>
{
    numbers.Result = numbers.Number1 - numbers.Number2;
    return Results.Ok(numbers);
})
.WithName("SubtractNumbers");

app.MapPost("/api/calculate/multiply", (Number numbers) =>
{
    numbers.Result = numbers.Number1 * numbers.Number2;
    return Results.Ok(numbers);
})
.WithName("MultiplyNumbers");

app.MapPost("/api/calculate/divide", (Number numbers) =>
{
    if (numbers.Number2 == 0)
        return Results.BadRequest("Cannot divide by zero");

    numbers.Result = numbers.Number1 / numbers.Number2;
    return Results.Ok(numbers);
})
.WithName("DivideNumbers");


app.Run();
