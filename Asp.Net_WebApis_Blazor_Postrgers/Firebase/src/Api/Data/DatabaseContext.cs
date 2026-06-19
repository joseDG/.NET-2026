using Api.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class DatabaseContext : DbContext
    {

    public DatabaseContext()
    {        
    }
        
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    //este metodo trae todas las herencias de Entity
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);
    }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Usuario> Usuarios {get;set;}
    }
}