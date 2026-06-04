using System.Collections.Generic;

namespace LeerData
{
    public class Libro
    {
        public int LibroId { get; set; }
        public string? Titulo { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaPublicacion { get; set; }

        //Referencia a la clase Precio
        public Precio? PrecioPromocion { get; set; }
        
        //Referencia a la clase Comentario
        public ICollection<Comentario>? ComentarioLista { get; set; }
        //Referencia a la clase LibroAutor
        public ICollection<LibroAutor> AutorLink { get; set; } = new List<LibroAutor>();
    }
}