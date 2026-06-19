using Strategy.Common;
using Strategy.Modifiers;

namespace Strategy
{
    class AppDemo : App
    {
        protected override int TransactionProcessNumber { get; } = 1;

        protected override void Implementation()
        {
            var libros = new HashSet<Libro>(new LibroTituloComparer());
            var sorted = new SortedList<string, Libro>();

            var libro1 = new Libro("Java Programming", new Money(50, new Currency("USD")));
            var libro2 = new Libro("Algoritmos", new Money(30, new Currency("USD")));
            var libro3 = new Libro("Csharp desde cero", new Money(60, new Currency("USD")));

            sorted.Add(libro1.Titulo!, libro1);
            sorted.Add(libro2.Titulo!, libro2);
            sorted.Add(libro3.Titulo!, libro3);

            foreach (var lb in sorted)
                Console.WriteLine(lb.Key);

        }



    }
}
