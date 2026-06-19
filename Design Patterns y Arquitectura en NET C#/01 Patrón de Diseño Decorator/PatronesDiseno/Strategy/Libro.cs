using Strategy.Common;

namespace Strategy
{
    public class Libro
    {
        public string? Titulo { get; }
        public virtual Money? Precio { get; }
        public Money? PrecioFinal { get; }

        public Libro(string? titulo, Money? precio): this(titulo, precio, precio)
        {
        }

        private Libro(string? titulo, Money? precio, Money? precioFinal) 
        {
            if (precio!.Currency != precioFinal!.Currency)
                throw new ArgumentException();

            PrecioFinal = precioFinal;
            Titulo = titulo;
            Precio = precio;
        }

        public virtual Libro WithPrecioFinal(Money precio) =>
            new Libro(Titulo, Precio, precio);


        public override string ToString() =>
            $"{Titulo}{Environment.NewLine}{PrecioToString()}";

        private string PrecioToString() =>
            PrecioFinal! == Precio! ? $"{PrecioFinal}" : $"{PrecioFinal} (anteriormente el precio fue {Precio}) ";

    }
}
