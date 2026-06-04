namespace App05;

public class Estudiante : IComparable<Estudiante>
{
    public static int EstudianteCount = 0;
    public string? Nombre { get; set; }
    public string? Apellido { get; set; }

    public Estudiante(string? nombre, string? apellido)
    {
        Nombre = nombre;
        Apellido = apellido;
        EstudianteCount++;
    }

    public override string ToString()
    {
        return $"Nombre: {Nombre}, Apellido: {Apellido}";
    }

    public int CompareTo(Estudiante? miEstudiante)
    {

        if (miEstudiante.Apellido == this.Apellido)
        {
            return this.Nombre!.CompareTo(miEstudiante?.Nombre);
        }
        return this.Apellido!.CompareTo(miEstudiante?.Apellido);

    }

    public record NombreCompleto(string Nombre, String Apellido);
}