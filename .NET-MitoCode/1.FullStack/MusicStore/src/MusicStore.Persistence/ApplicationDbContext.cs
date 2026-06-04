using Microsoft.EntityFrameworkCore;
using System.Reflection;
using MusicStore.Entities.Info;

namespace MusicStore.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        //Fluent API 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Customizing the migration - esto permite ejecutar todas las configuraicones de las entidades 
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Ignore<ConcertInfo>();
            //modelBuilder.Entity<ConcertInfo>().HasNoKey();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseLazyLoadingProxies();
        }


        //Entities to tables
        //public DbSet<Genre> Genres { get; set; }
    }
}
