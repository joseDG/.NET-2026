
using DecoratorApp.Common;

namespace DecoratorApp.HappyBirthday
{
    class PastelHandler
    {
        public void Handle(IPastel pastel) 
        {
            Size pastelPropaganda = new Size(142 * Length.Millimeter, 125 * Length.Millimeter, 5 * Length.Millimeter);

            Size pastelSize = pastel.GetDimensions(pastelPropaganda);

            Console.WriteLine($"Trabajando {pastel.GetType().Name} tamano {pastelSize} ");
        }
    }
}
