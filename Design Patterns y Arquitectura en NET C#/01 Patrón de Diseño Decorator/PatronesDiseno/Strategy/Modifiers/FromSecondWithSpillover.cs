using Strategy.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy.Modifiers
{
    public class FromSecondWithSpillover : CalculatingModifier
    {
        public FromSecondWithSpillover(IDeduction? deduction) : base(deduction)
        {
        }

        protected override (Money first, Money second) ApplyTo(Money a, Money b, Money deduction)
        {
            var bDeduction = b >= deduction ? deduction : b;
            var spill = deduction - bDeduction;
            var aDeduction = a >= spill ? spill : a;
            return (a - aDeduction, b - bDeduction);

        }
    }
}
