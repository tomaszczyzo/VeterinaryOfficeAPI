using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.OpenApi.Writers;
using VeterinaryOfficeAPI;
using VeterinaryOfficeAPI.Entities;
using VeterinaryOfficeAPI.Models;
using VeterinaryOfficeAPI.Models.Validators;
using VeterinaryOfficeAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<VeterinaryOfficeDbContext>();
builder.Services.AddScoped<VeterinaryOfficeSeeder>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IAnimalService, AnimalService>();
builder.Services.AddScoped<IValidator<CreateAnimalDto>, CreateAnimalDtoValidator>();
var app = builder.Build();
var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<VeterinaryOfficeSeeder>();
// Configure the HTTP request pipeline.
seeder.Seed();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
