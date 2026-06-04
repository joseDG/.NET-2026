using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AppStore.Models.Domain
{
    public class DatabaseContext : IdentityDbContext<ApplicationUser>
    {
        
        
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            
        }   

        //aplicando la relacion de muchos a muchos entre libros y categorias
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Configuracion de la relacion muchos a muchos entre libros y categorias
            builder.Entity<Libro>()
                .HasMany(l => l.CategoriaRelationList)
                .WithMany(c => c.LibroRelationList)
                .UsingEntity<LibroCategoria>(
                    j => j
                        .HasOne(lc => lc.Categoria)
                        .WithMany(c => c.LibroCategoriaRelationList)
                        .HasForeignKey(lc => lc.CategoriaId),
                    j => j
                        .HasOne(lc => lc.Libro)
                        .WithMany(l => l.LibroCategoriaRelationList)
                        .HasForeignKey(lc => lc.LibroId),
                    j =>
                    {
                        j.HasKey(t => new { t.LibroId, t.CategoriaId });
                    }
                );
        }


        //Entidaddes registradas
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<LibroCategoria> LibrosCategorias { get; set; }
    }
}