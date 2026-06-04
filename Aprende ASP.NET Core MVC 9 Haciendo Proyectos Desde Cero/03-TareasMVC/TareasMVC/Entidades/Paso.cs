namespace TareasMVC.Entidades
{
    public class Paso
    {
        public Guid Id { get; set; } //este permite crear un id aleatorio
        public int TareaId { get; set; } // clave foranea
        public Tarea Tarea { get; set; } // propiedad de navegacion
        public string Descripcion { get; set; }
        public bool Realizado { get; set; }
        public int Orden { get; set; }
    }
}
