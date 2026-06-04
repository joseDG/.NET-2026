namespace App05;

public class Autor : IComparable<Autor>
{

    public string? Nombre { get; set; }
    public string? Apellido { get; set; }


    public Autor(string? nombre, string? apellido)
    {
        Nombre = nombre;
        Apellido = apellido;
    }

    public override string ToString()
    {
        return $"{Nombre} {Apellido}";
    }

    public int CompareTo(Autor? other)
    {
        return this.ToString().CompareTo(other.ToString());
    }

    //public int CompareTo(object? obj)
    //{
    //    if (obj is null) return 1;
    //    if (obj is Autor miAutor)
    //    {
    //        return this.ToString().CompareTo(miAutor.ToString());
    //    }
    //    throw new ArgumentException("No es tipo Autor", nameof(obj));
    //}
}