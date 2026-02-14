// Entry point for the application
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(); // Register controllers

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen(); //Register Swagger generator to generate OpenAPI JSON

//Build the application
var app = builder.Build(); // Build the application and prepare middleware pipeline

// Configure middleware (HTTP request pipeline)
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger(); //swagger/v1/swagger.json. How are you
    app.UseSwaggerUI(); // /swagger
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run(); //Start the application
