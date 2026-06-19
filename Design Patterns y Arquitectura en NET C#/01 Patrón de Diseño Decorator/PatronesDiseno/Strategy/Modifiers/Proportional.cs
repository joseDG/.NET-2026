using Strategy.Common;

namespace Strategy.Modifiers
{
    public class Proportional : CalculatingModifier
    {
        public Proportional(IDeduction? deduction) : base(deduction)
        {
        }

        protected override (Money first, Money second) ApplyTo(Money a, Money b, Money deduction)
        {
            var factor = b / (a + b);
            var bDeductionFull = factor* deduction;
            var bDeduction = b >= bDeductionFull ?  bDeductionFull : b;
            var spill = deduction - bDeduction;
            var aDeduction = a >= spill ? spill : a;
            return (a - aDeduction, b - bDeduction);
        }
    }
}
