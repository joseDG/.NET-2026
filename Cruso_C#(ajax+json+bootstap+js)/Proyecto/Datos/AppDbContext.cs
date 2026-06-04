using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Proyecto.Models;

namespace Proyecto.Datos
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Curso> Cursos => Set<Curso>();
        public DbSet<Periodo> Periodo => Set<Periodo>();
        public DbSet<Alumno> Alumno => Set<Alumno>();
        public DbSet<Sexo> Sexo => Set<Sexo>();
        public DbSet<Docente> Docente => Set<Docente>();
        public DbSet<ModalidadContrato> ModalidadContrato => Set<ModalidadContrato>();
        public DbSet<Seccion> Seccion => Set<Seccion>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Curso>(e =>
            {
                // Nombre real de la tabla y (opcional) esquema
                e.ToTable("CURSO");                 // e.ToTable("CURSO", "dbo"); si tienes esquema distinto

                // Clave primaria
                e.HasKey(x => x.IIDCURSO);

                // Mapeo de columnas (si en BD están en mayúsculas)
                e.Property(x => x.IIDCURSO).HasColumnName("IIDCURSO");
                e.Property(x => x.NOMBRE).HasColumnName("NOMBRE");
                e.Property(x => x.DESCRIPCION).HasColumnName("DESCRIPCION");
                e.Property(x => x.BHABILITADO).HasColumnName("BHABILITADO");

                // (Opcional) Reglas adicionales si las conoces:
                // e.Property(x => x.NOMBRE).HasMaxLength(200).IsRequired(false);
                // e.Property(x => x.DESCRIPCION).HasMaxLength(500);
                // e.Property(x => x.IIDCURSO).ValueGeneratedOnAdd(); // si es IDENTITY
            });

            modelBuilder.Entity<Periodo>(e =>
            {
                // Tabla y (opcional) esquema
                e.ToTable("PERIODO");               // e.ToTable("PERIODO", "dbo");

                // Clave primaria
                e.HasKey(x => x.IIDPERIODO);

                // Si es IDENTITY en SQL Server:
                e.Property(x => x.IIDPERIODO)
                    .HasColumnName("IIDPERIODO")
                    .ValueGeneratedOnAdd();

                // NOMBRE (nullable según tu modelo)
                e.Property(x => x.NOMBRE)
                    .HasColumnName("NOMBRE")
                    .HasMaxLength(200)              // ajusta al tamaño real en BD
                    .IsUnicode(true)                // cambia a false si es VARCHAR
                    .IsRequired(false);             // nullable

                // Fechas (no nulas)
                e.Property(x => x.FECHAINICIO)
                    .HasColumnName("FECHAINICIO");
                // .HasColumnType("date");      // usa esto si en BD es DATE

                e.Property(x => x.FECHAFIN)
                    .HasColumnName("FECHAFIN");
                // .HasColumnType("date");

                // Habilitado (int 0/1)
                e.Property(x => x.BHABILITADO)
                    .HasColumnName("BHABILITADO")
                    .HasDefaultValue(1);

                // (Opcional) Índices
                // e.HasIndex(x => x.NOMBRE);
            });

            modelBuilder.Entity<Alumno>(entity =>
            {
                entity.ToTable("ALUMNO");                  // <-- ajusta esquema si usas otro (ej. .ToTable("ALUMNO","ESCOLAR"))

                entity.HasKey(e => e.IIDALUMNO);           // PK
                entity.Property(e => e.IIDALUMNO)
                      .HasColumnName("IIDALUMNO");         // .ValueGeneratedOnAdd() si es identity

                entity.Property(e => e.NOMBRE)
                      .HasColumnName("NOMBRE")
                      .HasMaxLength(100)                   // ajusta longitud real de la columna
                      .IsUnicode(false);

                entity.Property(e => e.APPATERNO)
                      .HasColumnName("APPATERNO")
                      .HasMaxLength(100)
                      .IsUnicode(false);

                entity.Property(e => e.APMATERNO)
                      .HasColumnName("APMATERNO")
                      .HasMaxLength(100)
                      .IsUnicode(false);

                entity.Property(e => e.FECHANACIMIENTO)
                      .HasColumnName("FECHANACIMIENTO")
                      .HasColumnType("date");              // usa "datetime" si tu motor no soporta "date"

                entity.Property(e => e.IIDSEXO)
                      .HasColumnName("IIDSEXO");

                entity.Property(e => e.TELEFONOMADRE)
                      .HasColumnName("TELEFONOMADRE")
                      .HasMaxLength(20)
                      .IsUnicode(false);

                entity.Property(e => e.TELEFONOPADRE)
                      .HasColumnName("TELEFONOPADRE")
                      .HasMaxLength(20)
                      .IsUnicode(false);

                entity.Property(e => e.NUMEROHERMANOS)
                      .HasColumnName("NUMEROHERMANOS")
                      .HasMaxLength(2)                     // si almacenas como texto; si es numérico, cambia el tipo en el modelo
                      .IsUnicode(false);

                entity.Property(e => e.BHABILITADO)
                      .HasColumnName("BHABILITADO")
                      .HasDefaultValue(1);                 // 1 = habilitado, ajusta si tu BD usa otro valor por defecto

                // Índices útiles (opcionales)
                entity.HasIndex(e => e.IIDSEXO).HasDatabaseName("IX_ALUMNO_IDSEXO");
                entity.HasIndex(e => new { e.APPATERNO, e.APMATERNO, e.NOMBRE }).HasDatabaseName("IX_ALUMNO_APELLIDOS_NOMBRE");
            });

            modelBuilder.Entity<Sexo>(entity =>
            {
                entity.ToTable("SEXO"); // .ToTable("SEXO", "ESQUEMA") si aplica

                entity.HasKey(e => e.IIDSEXO);

                entity.Property(e => e.IIDSEXO)
                      .HasColumnName("IIDSEXO");
                // .ValueGeneratedOnAdd(); // descomenta si es identity/autonumérico en BD

                entity.Property(e => e.NOMBRE)
                      .HasColumnName("NOMBRE")
                      .HasMaxLength(50)
                      .IsUnicode(false); // VARCHAR (no NVARCHAR)

                entity.Property(e => e.BHABILITADO)
                      .HasColumnName("BHABILITADO")
                      .HasDefaultValue(1); // 1 = habilitado

                // Índice útil para búsquedas por nombre (opcional)
                entity.HasIndex(e => e.NOMBRE)
                      .HasDatabaseName("IX_SEXO_NOMBRE");
                // .IsUnique(); // si no deseas duplicados de nombre
            });

            modelBuilder.Entity<Docente>(entity =>
            {
                entity.ToTable("DOCENTE"); // ajusta esquema si aplica: .ToTable("DOCENTE","ESQUEMA")

                entity.HasKey(e => e.IIDDOCENTE);

                entity.Property(e => e.IIDDOCENTE)
                      .HasColumnName("IIDDOCENTE");
                // .ValueGeneratedOnAdd(); // descomenta si es identity/autonumérico en tu BD

                entity.Property(e => e.NOMBRE)
                      .HasColumnName("NOMBRE")
                      .HasMaxLength(100)
                      .IsUnicode(false);

                // Nota: el campo recibido es "APARTAMENTO".
                // Si realmente debía ser "APPATERNO" (apellido paterno), corrige el nombre en tu clase/BD.
                entity.Property(e => e.APPATERNO)
                      .HasColumnName("APPATERNO")
                      .HasMaxLength(100)
                      .IsUnicode(false);

                entity.Property(e => e.APMATERNO)
                      .HasColumnName("APMATERNO")
                      .HasMaxLength(100)
                      .IsUnicode(false);

                entity.Property(e => e.DIRECCION)
                      .HasColumnName("DIRECCION")
                      .HasMaxLength(200)
                      .IsUnicode(false);

                entity.Property(e => e.TELEFONOCELULAR)
                      .HasColumnName("TELEFONOCELULAR")
                      .HasMaxLength(20)
                      .IsUnicode(false);

                entity.Property(e => e.TELEFONOFIJO)
                      .HasColumnName("TELEFONOFIJO")
                      .HasMaxLength(20)
                      .IsUnicode(false);

                entity.Property(e => e.EMAIL)
                      .HasColumnName("EMAIL")
                      .HasMaxLength(150)
                      .IsUnicode(false);

                entity.Property(e => e.IIDSEXO)
                      .HasColumnName("IIDSEXO");

                entity.Property(e => e.FECHACONTRATO)
                      .HasColumnName("FECHACONTRATO")
                      .HasColumnType("date"); // usa "datetime" si tu proveedor no soporta "date"

                entity.Property(e => e.FOTO)
                      .HasColumnName("FOTO")
                      .HasColumnType("varbinary(max)"); // SQL Server; ajusta para tu proveedor (bytea/BLOB)

                entity.Property(e => e.IIDMODALIDADCONTRATO)
                      .HasColumnName("IIDMODALIDADCONTRATO");

                entity.Property(e => e.BHABILITADO)
                      .HasColumnName("BHABILITADO")
                      .HasDefaultValue(1); // 1 = habilitado

                // Índices útiles
                entity.HasIndex(e => e.IIDSEXO)
                      .HasDatabaseName("IX_DOCENTE_IIDSEXO");

                entity.HasIndex(e => e.IIDMODALIDADCONTRATO)
                      .HasDatabaseName("IX_DOCENTE_IIDMODALIDAD");

                // Si EMAIL debe ser único en la BD, habilita:
                entity.HasIndex(e => e.EMAIL)
                      .HasDatabaseName("UX_DOCENTE_EMAIL")
                      .IsUnique();
            });

            modelBuilder.Entity<ModalidadContrato>(entity =>
            {
                entity.ToTable("MODALIDADCONTRATO"); // ajusta esquema si aplica

                entity.HasKey(e => e.IIDMODALIDADCONTRATO);

                entity.Property(e => e.IIDMODALIDADCONTRATO)
                      .HasColumnName("IIDMODALIDADCONTRATO");
                // .ValueGeneratedOnAdd(); // descomenta si es identity/autonumérico

                entity.Property(e => e.NOMBRE)
                      .HasColumnName("NOMBRE")
                      .HasMaxLength(100)
                      .IsUnicode(false);

                entity.Property(e => e.DESCRIPCION)
                      .HasColumnName("DESCRIPCION")
                      .HasMaxLength(250)
                      .IsUnicode(false);

                entity.Property(e => e.BHABILITADO)
                      .HasColumnName("BHABILITADO")
                      .HasDefaultValue(1); // 1 = habilitado

                // Índices útiles
                entity.HasIndex(e => e.NOMBRE)
                      .HasDatabaseName("UX_MODALIDADCONTRATO_NOMBRE")
                      .IsUnique(); // si el nombre no debe repetirse
            });

            modelBuilder.Entity<Seccion>(entity =>
            {
                // Tabla y clave
                entity.ToTable("SECCION");              // <- cambia si tu tabla se llama distinto
                entity.HasKey(e => e.IIDSECCION);

                // Columnas
                entity.Property(e => e.IIDSECCION)
                      .HasColumnName("IIDSECCION");

                entity.Property(e => e.NOMBRE)
                      .HasColumnName("NOMBRE")
                      .HasMaxLength(100)               // <- ajusta longitud
                      .IsUnicode(false);               // varchar en lugar de nvarchar

                entity.Property(e => e.BHABILITADO)
                      .HasColumnName("BHABILITADO")
                      .HasDefaultValue(1);            // por defecto habilitado
            });
        }

    }

}
