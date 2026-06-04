using Bogus;
using MasterNet.Domain;
using MasterNet.Persistence;
using MasterNet.Persistence.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MasterNet.WebApi.Extensions;

public static class DataSeed
{



    public static async Task SeedDataAuthentication(
        this IApplicationBuilder app
    )
    {
        using var scope = app.ApplicationServices.CreateScope();
        var service = scope.ServiceProvider;
        var loggerFactory = service.GetRequiredService<ILoggerFactory>();

        try
        {
            var context = service.GetRequiredService<MasterNetDbContext>();
            await context.Database.MigrateAsync();
            var userManager = service.GetRequiredService<UserManager<AppUser>>();

            if (!userManager.Users.Any())
            {
                var userAdmin = new AppUser
                {
                    NombreCompleto = "Vaxi Drez",
                    UserName = "vaxidrez",
                    Email = "vaxi.drez@gmail.com"
                };

                await userManager.CreateAsync(userAdmin, "Password123$");
                await userManager.AddToRoleAsync(userAdmin, CustomRoles.ADMIN);

                var userClient = new AppUser
                {
                    NombreCompleto = "Juan Perez",
                    UserName = "juanperez",
                    Email = "juan.perez@gmail.com"
                };

                await userManager.CreateAsync(userClient, "Password123$");
                await userManager.AddToRoleAsync(userClient, CustomRoles.CLIENT);
            }

            var cursos = GenerateCursos();

            if (!context.Set<Curso>().Any())
            {
                context.AddRange(cursos);
            }

            var instructores = GenerateInstructores();

            if (!context.Set<Instructor>().Any())
            {
                context.AddRange(instructores);
            }

            var precios = GeneratePrecios();
            if (!context.Set<Precio>().Any())
            {
                context.AddRange(precios);
            }


            //var cursos = await context.Cursos!.Take(10).Skip(0).ToListAsync();

            if (!context.Set<CursoInstructor>().Any())
            {
                //var instructores =
                //await context.Instructores!.Take(10).Skip(0).ToListAsync();

                foreach (var curso in cursos)
                {
                    curso.Instructores = instructores;
                }
            }

            if (!context.Set<CursoPrecio>().Any())
            {
                //var precios = await context.Precios!.ToListAsync();
                foreach (var curso in cursos)
                {
                    curso.Precios = precios;
                }
            }

            if (!context.Set<Calificacion>().Any())
            {
                foreach (var curso in cursos)
                {
                    var fakerCalificacion = new Faker<Calificacion>()
                        .RuleFor(c => c.Id, _ => Guid.NewGuid())
                        .RuleFor(c => c.Alumno, f => f.Name.FullName())
                        .RuleFor(c => c.Comentario, f => f.Commerce.ProductDescription())
                        .RuleFor(c => c.Puntaje, 5)
                        .RuleFor(c => c.CursoId, curso.Id);

                    var calificaciones = fakerCalificacion.Generate(10);
                    context.AddRange(calificaciones);
                }
            }


            await context.SaveChangesAsync();

        }
        catch (Exception e)
        {
            var logger = loggerFactory.CreateLogger<MasterNetDbContext>();
            logger.LogError(e.Message);
        }


    }
    private static List<Curso> GenerateCursos()
    {
        var faker = new Faker<Curso>()
            .RuleFor(c => c.Id, _ => Guid.NewGuid())
            .RuleFor(c => c.Titulo, f => f.Lorem.Sentence())
            .RuleFor(c => c.Descripcion, f => f.Lorem.Paragraph())
            .RuleFor(c => c.FechaPublicacion, f => f.Date.Past())
            .RuleFor(c => c.Calificaciones, _ => new List<Calificacion>())
            .RuleFor(c => c.Precios, _ => new List<Precio>())
            .RuleFor(c => c.CursoPrecios, _ => new List<CursoPrecio>())
            .RuleFor(c => c.Instructores, _ => new List<Instructor>())
            .RuleFor(c => c.CursoInstructores, _ => new List<CursoInstructor>())
            .RuleFor(c => c.Photos, _ => new List<Photo>());

        return faker.Generate(20);
    }
    private static List<Instructor> GenerateInstructores()
    {
        var faker = new Faker<Instructor>()
            .RuleFor(i => i.Id, _ => Guid.NewGuid())
            .RuleFor(i => i.Apellidos, f => f.Name.LastName())
            .RuleFor(i => i.Nombre, f => f.Name.FirstName())
            .RuleFor(i => i.Grado, f => f.Name.JobTitle())
            .RuleFor(i => i.Cursos, _ => new List<Curso>())
            .RuleFor(i => i.CursoInstructores, _ => new List<CursoInstructor>());

        return faker.Generate(20);
    }
    private static List<Precio> GeneratePrecios()
    {
        var faker = new Faker<Precio>()
            .RuleFor(p => p.Id, _ => Guid.NewGuid())
            .RuleFor(p => p.Nombre, f => f.Commerce.ProductName())
            .RuleFor(p => p.PrecioActual, f => f.Finance.Amount(10, 100))
            .RuleFor(p => p.PrecioPromocion, f => f.Finance.Amount(5, 50))
            .RuleFor(p => p.Cursos, _ => new List<Curso>())
            .RuleFor(p => p.CursoPrecios, _ => new List<CursoPrecio>());

        return faker.Generate(4);
    }




}