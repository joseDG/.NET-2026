using Api.Data;
using Api.Models.Domain;
using Bogus;


namespace Api.Extensions
{
    public static class DataPruebaExtensions
    {
        public static async void AddDataPrueba(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var service = scope.ServiceProvider;
            var dbContext = service.GetRequiredService<DatabaseContext>();

            if (!dbContext.Productos.Any())
            {
                var productoColletion = new List<Producto>();
                var faker = new Faker();
                for (int i = 1; i <= 1000; i++)
                {
                    productoColletion.Add(new Producto         
                    {
                        Nombre = faker.Commerce.ProductName(),
                        Descripcion = faker.Commerce.ProductDescription(),
                        Precio = faker.Random.Decimal(100, 5000)
                    });

                }

                await dbContext.Productos.AddRangeAsync(productoColletion);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}