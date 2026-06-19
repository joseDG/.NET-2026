using Strategy.Common;

namespace Strategy
{
    public class TakeTwoOffer
    {
        private Libro? First { get; }
        private Libro? Second { get; }

        private IPrecioModifier Modifier { get; }

        public TakeTwoOffer(IPrecioModifier modifier)
        {
            Modifier = modifier;
        }

        public (Libro first, Libro second) ApplyTo(Libro first, Libro second) => 
            ReducirPrecioAlBarato(first, second);

        private (Libro caro, Libro barato) Sort(Libro first, Libro second) =>
            first.Precio! >= second.Precio! ? (first, second) : (second, first);


        private (Libro first, Libro second) ReducirPrecioAlBarato(Libro first, Libro second)
        {
            var libros = Sort(first, second);
            var precios = Modifier.ApplyTo(libros.caro.Precio!, libros.barato.Precio!);

            return (
                    libros.caro.WithPrecioFinal(precios.first!),
                    libros.barato.WithPrecioFinal(precios.second!));
                
        }
    }
}
