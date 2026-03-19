using AbonadosMunicipio.Infraestructura.DataBase;
using Microsoft.EntityFrameworkCore;
using AbonadosMunicipio.Infraestructura.Interfaces;
using AbonadosMunicipio.Infraestructura.Repositorios;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Base de datos
builder.Services.AddDbContext<AbonadosDbContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("DbServiciosPublicosConnectionString"))
);

//Servicios
builder.Services.AddScoped<IdAbonadosRepositorio, AbonadosRepositorio>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
