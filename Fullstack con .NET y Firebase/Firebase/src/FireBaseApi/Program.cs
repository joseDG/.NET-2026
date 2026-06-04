using FirebaseAdmin;
using FireBaseApi;
using FireBaseApi.Data;
using FireBaseApi.Extensions;
using FireBaseApi.Services.Authentication;
using FireBaseApi.Services.Productos;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//Configuracion de Postgress
var connectionString = builder.Configuration
    .GetConnectionString("ConnectionString") ?? throw new ArgumentNullException("No tiene cadena conexion");

builder.Services.AddDbContext<DatabaseContext>(opt =>
{
    opt.UseNpgsql(connectionString);
});

//configurando SignalR
builder.Services.AddSignalR();
builder.Services.AddHostedService<ServerNotifier>();


//Configuracion de FireBase
FirebaseApp.Create(new AppOptions()
{
    Credential = GoogleCredential.FromFile("firebase.json")
});

//builder.Services.AddSingleton<IAuthenticationService, AuthenticationService>();
builder.Services.AddHttpClient<IAuthenticationService, AuthenticationService>((sp, httClient) =>
{
    var configuration = sp.GetRequiredService<IConfiguration>();
    httClient.BaseAddress = new Uri(configuration["Authentication:TokenUri"]!);
});

//registar Authentication
builder.Services
    .AddAuthentication()
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, jwtOptions =>
    {
        jwtOptions.Authority = builder.Configuration["Authentication:ValidIssuer"];
        jwtOptions.Audience = builder.Configuration["Authentication:Audience"];
        jwtOptions.TokenValidationParameters.ValidIssuer = builder.Configuration["Authentication:ValidIssuer"];
    });

//Configuracion de la Base de datos
//builder.Services.AddDbContext<DatabaseContext>(opt =>
//{
//    opt.LogTo(Console.WriteLine, new  [] {
//        DbLoggerCategory.Database.Command.Name
//        },
//        LogLevel.Information
//    ).EnableSensitiveDataLogging();

//    opt.UseSqlite(builder.Configuration.GetConnectionString("SqliteDatabase"));
//});

//Registrar servicios
builder.Services.AddScoped<IProductoService, ProductoService>();


//Registrar los Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
    );

});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

//registrar los Cors
app.UseCors("CorsPolicy");

app.MapControllers();

app.UseAuthentication();
app.UseAuthorization();

//se llama alos datos de prueba
app.AddDataPrueba();

app.MapHub<NotificationHub>("notifications");

app.Run();
