using DecoratorApp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorApp.HappyBirthday
{
    class HappyBirthdayFiesta : AbstractFiesta
    {
        protected override int EventNumber { get;  } = 1;
        protected override void Implementation()
        {
            IPastel pastelPack = new PastelPreparado(
                "Cumple de Juan",
                new Size(188 * Length.Millimeter, 239 * Length.Millimeter, 28 * Length.Millimeter)
                );

            IPastel paquetePastel = new PastelPackTotal(pastelPack);


            var comprador = new PastelHandler();
            comprador.Handle(paquetePastel);

            IPastel wrappedPastel = new WrappedPastel(paquetePastel);

            var empleado = new PastelHandler();
            empleado.Handle(wrappedPastel);
        }
    }
}
