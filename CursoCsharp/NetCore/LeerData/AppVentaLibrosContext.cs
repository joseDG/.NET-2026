using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace LeerData
{
    public class AppVentaLibrosContext : DbContext
    {
        private const string ConnectionString = @"Data Source=JOSH\SQLEXPRESS; Initial Catalog=LibrosWeb; Integrated Security=True; Encrypt=False;";
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Establecer cuando existen mas de una llave primeria en la tabla de relacion.
            modelBuilder.Entity<LibroAutor>().HasKey(la => new { la.LibroId, la.AutorId });
        }

        public DbSet<Libro> Libro { get; set; }
        public DbSet<Precio> Precio { get; set; }
        public DbSet<Comentario> Comentario { get; set; }
        public DbSet<Autor> Autor { get; set; }
        public DbSet<LibroAutor> LibroAutor { get; set; }
    }
}