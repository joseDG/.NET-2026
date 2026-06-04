using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Proyecto.Models
{
    public class Alumno
    {
        public int IIDALUMNO { get; set; }
        public string? NOMBRE { get; set; }
        public string? APPATERNO { get; set; }
        public string? APMATERNO { get; set; }
        public DateTime FECHANACIMIENTO { get; set; }
        public int IIDSEXO { get; set; }
        public string? TELEFONOMADRE { get; set; }
        public string? TELEFONOPADRE { get; set; }
        public string? NUMEROHERMANOS { get; set; }
        public int BHABILITADO { get; set; }
    }
}
