using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi;


var builder = WebApplication.CreateBuilder(args);

// Optional: add OpenAPI/Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My CI/CD App", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Simple root endpoint
app.MapGet("/", () => new
{
    message = "Hello from .NET 10 CI/CD sample!",
    time = DateTime.UtcNow
});

// Health check endpoint for CI/CD
app.MapGet("/health", () => Results.Ok("OK"));

// Example route with parameter
app.MapGet("/greet/{name}", (string name) =>
    Results.Ok(new { greeting = $"Hello, {name}!" })
);

app.Run();
