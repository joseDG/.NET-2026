using CP.Portal.Movies.Module;
using FastEndpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMovieServices();
builder.Services.AddOpenApi();

//Agregando el FastEndpoints
builder.Services.AddFastEndpoints();


var app = builder.Build();


app.UseFastEndpoints();

app.Run();