using Microsoft.EntityFrameworkCore;
using ToDoApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=todo.db"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/api/todos", async (AppDbContext db) => await db.ToDoItems.ToListAsync())
    .WithName("GetAllToDos");

app.MapGet("/api/todos/{id}", async (int id, AppDbContext db) =>
    await db.ToDoItems.FindAsync(id) is ToDoItem todo ? Results.Ok(todo) : Results.NotFound())
    .WithName("GetToDoById");

app.MapPost("/api/todos", async (ToDoItem todo, AppDbContext db) =>
{
    db.ToDoItems.Add(todo);
    await db.SaveChangesAsync();
    return Results.Created($"/api/todos/{todo.Id}", todo);
}).WithName("CreateToDo");

app.MapPut("/api/todos/{id}", async (int id, ToDoItem input, AppDbContext db) =>
{
    var todo = await db.ToDoItems.FindAsync(id);
    if (todo == null) return Results.NotFound();

    todo.Title = input.Title;
    todo.IsCompleted = input.IsCompleted;
    await db.SaveChangesAsync();
    return Results.NoContent();
}).WithName("UpdateToDo");

app.MapDelete("/api/todos/{id}", async (int id, AppDbContext db) =>
{
    var todo = await db.ToDoItems.FindAsync(id);
    if (todo == null) return Results.NotFound();

    db.ToDoItems.Remove(todo);
    await db.SaveChangesAsync();
    return Results.NoContent();
}).WithName("DeleteToDo");

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}

app.Run();

