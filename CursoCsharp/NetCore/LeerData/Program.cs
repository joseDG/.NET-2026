using Microsoft.EntityFrameworkCore;

namespace LeerData
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new AppVentaLibrosContext())
            {
                var libros = db.Libro.Include(x => x.AutorLink).ThenInclude(la => la.Autor);

                foreach (var libro in libros)
                {
                    Console.WriteLine($"Título: {libro.Titulo}");
                    foreach (var autorLink in libro.AutorLink)
                    {
                        Console.WriteLine($"Autor: {autorLink.Autor!.Nombre}");
                    }
                   
                }
            }
        }
    }
}