using FireBaseApi.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace FireBaseApi.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options)
        {
        }

        public DbSet<Producto> Productos { get; set; }
    }
}
