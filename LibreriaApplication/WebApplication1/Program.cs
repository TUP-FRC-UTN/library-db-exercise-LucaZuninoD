using Libreria.Context;
using Libreria.Repositorios.implementaciones;
using Libreria.Repositorios.interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// Configuración de servicios
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Tu API", Version = "v1" });
});


// Configuración de DbContext para Entity Framework Core
builder.Services.AddDbContext<LibreriaDbContext>(options =>
    options.UseSqlServer(@"Data Source=LUCA\SQLEXPRESS;Database=LibreriaDB;Trusted_Connection=True;"));

// Registra los repositorios
builder.Services.AddScoped<ILibroRepository, LibroRepository>();
builder.Services.AddScoped<IAutorRepository, AutorRepository>();
builder.Services.AddScoped<IGeneroRepository, GeneroRepository>();





var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Libreria v1"));
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();

app.MapControllers();

app.Run();
