using BibliotecaAPI.Datos;
using BibliotecaAPI.Interfaces;
using BibliotecaAPI.Middleware;
using BibliotecaAPI.Repositorios;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

//Area de Servicios

builder.Services.AddTransient<ServicioTransient>();
builder.Services.AddScoped<ServicioScoped>();
builder.Services.AddSingleton<ServicioSingleton>();

builder.Services.AddSingleton<IRepositorioValores, RepositorioValoresOracle > ();

builder.Services.AddControllers().AddJsonOptions(options =>
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


//conexion a base de datos
builder.Services.AddDbContext<ApplicationDbContext>(opciones =>
    opciones.UseSqlServer("name=DefaultConnection"));


var app = builder.Build();

//Area de Middlewares
app.UseLogueaPeticion();

app.UseBloqueaPeticion();

app.MapControllers();

app.Run();
