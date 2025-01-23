var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors();
app.UseHttpsRedirection();

app.UseStaticFiles(); // Serve uploaded files

app.MapPost("/api/upload", async (HttpRequest request) =>
{
    if (!request.Form.Files.Any())
        return Results.BadRequest("No file uploaded.");

    var file = request.Form.Files[0];
    var description = request.Form["description"].FirstOrDefault(); // Extract the first value as a string

    if (string.IsNullOrWhiteSpace(description))
        return Results.BadRequest("Description is required.");

    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

    var filePath = Path.Combine(uploadsFolder, file.FileName);
    await using var fileStream = new FileStream(filePath, FileMode.Create);
    await file.CopyToAsync(fileStream);

    // Generate the full URL
    var baseUrl = $"{request.Scheme}://{request.Host}";
    var fileUrl = $"{baseUrl}/uploads/{file.FileName}";

    var result = new { FileUrl = fileUrl, Description = description };

    return Results.Json(result); // Explicitly return JSON
}).Accepts<IFormFile>("multipart/form-data");


app.Run();