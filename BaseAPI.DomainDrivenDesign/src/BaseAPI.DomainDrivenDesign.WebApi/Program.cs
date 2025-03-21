using BaseAPI.DomainDrivenDesign.Application.Services;
using BaseAPI.DomainDrivenDesign.Application.Services.Interfaces;
using BaseAPI.DomainDrivenDesign.Domain.Repositories;
using BaseAPI.DomainDrivenDesign.Infrastructure.Context;
using BaseAPI.DomainDrivenDesign.Infrastructure.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); // AutoMapper

builder.Services.AddFluentValidationAutoValidation(); // FluentValidation
builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

// Services
builder.Services.AddScoped<IWeatherForecastService, WeatherForecastService>();

// Repositories
builder.Services.AddScoped<IWeatherForecastRepository, WeatherForecastRepository>();

// Register DbContext Factory with DI container for IDbContextFactory<AppContext>
builder.Services.AddDbContextFactory<DbAppContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

// Enable Swagger for all environments (development and production)
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
});

app.Run();
