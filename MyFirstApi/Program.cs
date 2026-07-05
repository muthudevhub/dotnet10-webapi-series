// Entry point for the application
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(); // Register controllers

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen(); //Register Swagger generator to generate OpenAPI JSON

// Add Authentication
// Service registration (Dependency Injection setup)

builder
    .Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters =
            new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes("your-secret-key-welcome-to-muthudevhub")
                ),
            };
    });

// Add Authorization
// Service registration (Dependency Injection setup)
// Authorization is added after Authentication because it relies on the user being authenticated first
builder.Services.AddAuthorization(); //Enable access control rules for your app

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

// ORDER IS CRITICAL

// Middleware registration (HTTP pipeline setup)
app.UseAuthentication(); // Step 1: Validate token (passport scan) e.g. "Do you have a valid ticket?" (security guard)

// Middleware registration (HTTP pipeline setup)
app.UseAuthorization(); // Step 2: Check access (security gate) e.g. "You can enter the VIP lounge but not the backstage"

app.MapControllers();

app.Run(); //Start the application
