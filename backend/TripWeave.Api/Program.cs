using Microsoft.EntityFrameworkCore;
using TripWeave.Api.Data;
using TripWeave.Api.Interfaces;
using TripWeave.Api.Services;
using TripWeave.Api.Configuration;
using TripWeave.Api.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.Configure<TripSettings>(
    builder.Configuration.GetSection("TripSettings")
);

builder.Services.AddSingleton<ITripService, TripService>();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

var connectionString = builder.Configuration
    .GetConnectionString("TripWeaveDb");

if (string.IsNullOrWhiteSpace(connectionString))
{
    throw new InvalidOperationException(
        "TripWeave database connection string is missing."
    );
}

builder.Services.AddDbContext<TripWeaveDbContext>(
    options => options.UseNpgsql(connectionString)
);

var app = builder.Build();

app.UseExceptionHandler();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
