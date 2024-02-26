using DesafioAec.Application;
using DesafioAec.Domain.Interfaces;
using DesafioAec.Domain.Models;
using DesafioAec.Infra.DataContext;
using DesafioAec.Infra.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var conectionString = builder.Configuration.GetConnectionString("DefaultConnection");
Inicializar.Configuration(builder.Services, conectionString);

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
