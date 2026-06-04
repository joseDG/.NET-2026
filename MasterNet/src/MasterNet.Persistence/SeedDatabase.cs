using System.Collections.Frozen;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Bogus.Bson;
using MasterNet.Domain;
using MasterNet.Persistence.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;

namespace MasterNet.Persistence;

public static class SeedDatabase
{


    public static async Task SeedRolesAndUsersAsync(
        DbContext context,
        ILogger? logger,
        CancellationToken cancellationToken
    )
    {
        try
        {
            var userManager = context.GetService<UserManager<AppUser>>();
            var roleManager = context.GetService<RoleManager<IdentityRole>>();

            if(userManager.Users.Any()) return;

            //var adminId = "d3b07384-d9a0-4c8b-9e5d-1c2c3e4f5678";
            //var clientId = "e4da3b7f-bbce-4d8a-9e5d-1c2c3e4f5678";
            
        }catch (Exception ex)
        {
            logger?.LogWarning(ex, "Fallo cargando la data de usuarios y roles");
        }        
    }

    public static async Task SeedPreciosAsync(
        MasterNetDbContext dbContext,
        ILogger? logger,
        CancellationToken cancellationToken
    )
    {

        try
        {
            if (dbContext.Precios is null || dbContext.Precios.Any()) return;
            var jsonString = GetJsonFile("precios.json");

            if (jsonString is null) return;

            var precios = System.Text.Json.JsonSerializer.Deserialize<List<Precio>>(jsonString);

            if (precios is null || precios.Any() == false) return;

            dbContext.Precios.AddRange(precios!);
            await dbContext.SaveChangesAsync(cancellationToken);

        }
        catch (Exception ex)
        {
            logger?.LogWarning(ex, "Fallo cargando la data de precios");
        }
    }

    public static async Task SeedInstructoresAsync(
        MasterNetDbContext dbContext,
        ILogger? logger,
        CancellationToken cancellationToken
    )
    {

        try
        {
            if (dbContext.Instructores is null || dbContext.Instructores.Any()) return;
            var jsonString = GetJsonFile("instructores.json");

            if (jsonString is null) return;

            var instructores = System.Text.Json.JsonSerializer.Deserialize<List<Instructor>>(jsonString);

            if ( instructores is null || instructores.Any()==false) return;

            dbContext.Instructores.AddRange(instructores!);
            await dbContext.SaveChangesAsync(cancellationToken);

        }
        catch (Exception ex)
        {
            logger?.LogWarning(ex, "Fallo cargando la data de instructores");
        }
    }


    public static async Task SeedCursosAsync(
        MasterNetDbContext dbContext,
        ILogger? logger,
        CancellationToken cancellationToken
    )
    {

        try
        {
            if (dbContext.Cursos is null || dbContext.Cursos.Any()) return;
            var jsonString = GetJsonFile("cursos.json");

            if (jsonString is null) return;



            var instructores = dbContext
                                .Instructores!
                                .ToFrozenDictionary(p => p.Id, p => p);


            var precios = dbContext
                            .Precios!
                            .ToFrozenDictionary(p => p.Id, p => p);

            using var jsonDocument = System.Text.Json.JsonDocument.Parse(jsonString);

            if (jsonDocument.RootElement.ValueKind != System.Text.Json.JsonValueKind.Array) return;

            var cursosDb = new List<Curso>();

            foreach (var obj in jsonDocument.RootElement.EnumerateArray())
            {
                var idString = obj.TryGetProperty("Id", out var idElement) ? idElement.GetString() : null;
                if (!Guid.TryParse(idString, out var id))
                    id = Guid.NewGuid();

                var titulo = obj.TryGetProperty("Titulo", out var tituloElement) ? tituloElement.GetString() : null;
                var descripcion = obj.TryGetProperty("Descripcion", out var descripcionElement) ? descripcionElement.GetString() : null;

                DateTime? fechaPublicacion = null;
                var fechaPublicacionStr = obj.TryGetProperty("FechaPublicacion", out var fechaElement)
                    ? fechaElement.GetString()
                    : null;

                if (!string.IsNullOrWhiteSpace(fechaPublicacionStr) && DateTime.TryParse(fechaPublicacionStr, out var fp))
                {
                    fechaPublicacion = fp;
                }

                var curso = new Curso
                {
                    Id = id,
                    Titulo = titulo,
                    Descripcion = descripcion,
                    FechaPublicacion = fechaPublicacion,
                    Calificaciones = new List<Calificacion>(),
                    Precios = new List<Precio>(),
                    CursoPrecios = new List<CursoPrecio>(),
                    Instructores = new List<Instructor>(),
                    CursoInstructores = new List<CursoInstructor>(),
                    Photos = new List<Photo>()
                };

                if (obj.TryGetProperty("Precios", out var preciosElement) &&
                    preciosElement.ValueKind == System.Text.Json.JsonValueKind.Array)
                {
                    foreach (var pid in preciosElement.EnumerateArray())
                    {
                        var precioIdString = pid.GetString();
                        if (!string.IsNullOrWhiteSpace(precioIdString) &&
                            Guid.TryParse(precioIdString, out var idt) &&
                            precios.TryGetValue(idt, out var precio))
                        {
                            curso.Precios.Add(precio);
                        }
                    }
                }

                if (obj.TryGetProperty("Instructores", out var instructoresElement) &&
                    instructoresElement.ValueKind == System.Text.Json.JsonValueKind.Array)
                {
                    foreach (var iid in instructoresElement.EnumerateArray())
                    {
                        var instructorIdString = iid.GetString();
                        if (!string.IsNullOrWhiteSpace(instructorIdString) &&
                            Guid.TryParse(instructorIdString, out var idt) &&
                            instructores.TryGetValue(idt, out var instructor))
                        {
                            curso.Instructores.Add(instructor);
                        }
                    }
                }

                cursosDb.Add(curso);
            }


            await dbContext.Cursos.AddRangeAsync(cursosDb);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            logger?.LogWarning(ex, "Fallo cargando la data de cursos");
        }
    }

    public static async Task SeedCalificacionesAsync(
        MasterNetDbContext dbContext,
        ILogger? logger,
        CancellationToken cancellationToken
    )
    {

        try
        {
            if (dbContext.Calificaciones is null || dbContext.Calificaciones.Any()) return;
            var jsonString = GetJsonFile("calificaciones.json");

            if (jsonString is null) return;

            var calificaciones = System.Text.Json.JsonSerializer.Deserialize<List<Calificacion>>(jsonString);

            if (calificaciones is null || calificaciones.Any()==false) return;

            foreach (var ca in calificaciones!)
            {
                ca.Curso = null;
            }

            dbContext.Calificaciones.AddRange(calificaciones!);
            await dbContext.SaveChangesAsync(cancellationToken);

        }
        catch (Exception ex)
        {
            logger?.LogWarning(ex, "Fallo cargando la data de calificaciones");
        }
    }


    private static string GetJsonFile(string fileName)
    {
        var leerForma1 = Path.Combine(
            Directory.GetCurrentDirectory(),
            "src",
            "MasterNet.Persistence",
            "SeedData",
            fileName
        );

        var leerForma2 = Path.Combine(
            Directory.GetCurrentDirectory(),
            "SeedData",
            fileName
        );

        var leerForma3 = Path.Combine(
            AppContext.BaseDirectory,
            "SeedData",
            fileName
        );

        if (File.Exists(leerForma1)) return File.ReadAllText(leerForma1);
        if (File.Exists(leerForma2)) return File.ReadAllText(leerForma2);
        if (File.Exists(leerForma3)) return File.ReadAllText(leerForma3);

        return null!;
    }
}