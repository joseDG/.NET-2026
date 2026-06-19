using Api;
using Api.Authentication;
using Api.Data;
using Api.Extensions;
using Api.Pagination;
using Api.Services.Authentication;
using Api.Services.Permisos;
using Api.Services.Productos;
using AutoMapper;
using Firebase.Api.Pagination;
using Firebase.Mappings;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Agregando la conexion de postregresql
var connectionString = builder.Configuration
    .GetConnectionString("ConnectionString")
    ?? throw new ArgumentNullException("No tiene cadena de conexion");

//Agregando el servicio de Firebase
FirebaseApp.Create(new AppOptions()
{
    Credential = GoogleCredential.FromFile("firebase.json")
});

//Agregando SignalR
builder.Services.AddSignalR();

//Agregando el serverNotifier
builder.Services.AddHostedService<ServerNotifier>();

//Agregando los servicios 
//builder.Services.AddSingleton<IAuthenticationService, AuthenticationService>();
builder.Services.AddHttpClient<IAuthenticationService, AuthenticationService>((sp, httplClient) =>
{
    var configuration = sp.GetRequiredService<IConfiguration>();
    httplClient.BaseAddress = new Uri(configuration["Authentication:TokenUri"]!);
});

//Agregando el servicio de autenticación
builder.Services
    .AddAuthentication()
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, jwtOptions =>
    {
        jwtOptions.Authority = builder.Configuration["Authentication:ValidIssuer"];
        jwtOptions.Audience = builder.Configuration["Authentication:Audience"];
        jwtOptions.TokenValidationParameters.ValidIssuer = builder.Configuration["Authentication:ValidIssuer"];
    });

//Authorizacion implementaro el servicio
builder.Services.AddAuthorization();
builder.Services.AddSingleton<IAuthorizationHandler, PermisoAuthorizationHandler>();
builder.Services.AddSingleton<IAuthorizationPolicyProvider, PermisoAuthorizationPolicyProvider>();
builder.Services.AddScoped<IPermisoService, PermisoService>();

//Agregnado la configuracion de la base de datos  Sqlite
builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.LogTo(Console.WriteLine, new[] {
        DbLoggerCategory.Database.Command.Name
    },
    LogLevel.Information).EnableSensitiveDataLogging();

    options.UseNpgsql(builder.Configuration.GetConnectionString("ConnectionString"));

});

//Agregando AutoMapper
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

//Agregnado servicio de producto
builder.Services.AddScoped<IProductoService, ProductoService>();

//Agregando servicios de la paginacion
builder.Services.AddScoped<IPagedList, PagedList>();

//Agregando los Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.MapControllers();

app.UseAuthentication();

app.UseAuthorization();

app.AddDataPrueba();

app.MapHub<NotificationHub>("notifications");

app.Run();


