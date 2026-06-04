using Bogus;
using FireBaseApi.Data;
using FireBaseApi.Models.Domain;

namespace FireBaseApi.Extensions;

public static class DataPruebaExtensions
{
    public static async void AddDataPrueba(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var service = scope.ServiceProvider;
        var dbContext = service.GetRequiredService<DatabaseContext>();

        if (!dbContext.Productos.Any())
        {
            var productoCollection = new List<Producto>();
            var faker = new Faker();
            for (int i = 1; i <= 1000; i++)
            {
                productoCollection.Add(new Producto
                {
                    Nombre = faker.Commerce.ProductName(), 
                    Descripcion = faker.Commerce.ProductDescription(), 
                    Precio = faker.Random.Decimal(100, 50000)
                });
            }
            await dbContext.Productos.AddRangeAsync(productoCollection);
            await dbContext.SaveChangesAsync();
        }
    }
}