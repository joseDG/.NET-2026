

namespace LeerData
{
    public class Comentario
    {
        public int ComentarioId { get; set; }
        public string? Alumno { get; set; }
        public int Puntaje { get; set; }
        public string? ComentarioTexto { get; set; }
        public int LibroId { get; set; }

        //Referencia a la clase Libro
        public Libro? Libro { get; set; }
    }
}