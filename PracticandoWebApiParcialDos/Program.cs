///////////////////////////////////////////////
// USINGS
using Microsoft.EntityFrameworkCore;
using PracticandoWebApiParcialDos.Data;
using PracticandoWebApiParcialDos.Services;
///////////////////////////////////////////////

var builder = WebApplication.CreateBuilder(args);

///////////////////////////////////////////////
// NUEVO: AGREGAMOS CADENA DE CONEXION Y CONTEXTO
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseInMemoryDatabase("VentasDB"));

// REGISTRAMOS LOS SERVICIOS A USAR
builder.Services.AddScoped<RolService>();
builder.Services.AddScoped<UsuarioService>();

///////////////////////////////////////////////

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
