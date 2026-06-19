using DecoratorApp.Common;

namespace DecoratorApp.HappyBirthday
{
    class PastelPreparado : IPastel
    {
        public string? Nombre { get; }
        public Size? Dimensions { get; }

        public PastelPreparado(string? nombre, Size? dimensions)
        {
            Nombre = nombre;
            Dimensions = dimensions;
        }

        public Size GetDimensions(Size propaganda) => Dimensions!.AddToTop(propaganda);

        public override string ToString() => $"{Nombre} - {Dimensions}";

    }
}
