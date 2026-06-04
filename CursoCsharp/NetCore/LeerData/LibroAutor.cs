
namespace LeerData
{
    public class LibroAutor
    {
        public int AutorId { get; set; }
        public int LibroId { get; set; }
        //Referencia a la clase Libro
        public Libro? Libro { get; set; }
        //Referencia a la clase Autor
        public Autor? Autor { get; set; }
    }
}