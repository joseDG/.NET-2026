
namespace LeerData
{
    public class Precio
    {
        public int PrecioId { get; set; }
        public decimal PrecioActual { get; set; }
        public decimal Promocion { get; set; }
        public int LibroId { get; set; }

        //Referencia a la clase Libro
        public Libro? Libro { get; set; }
    }
}