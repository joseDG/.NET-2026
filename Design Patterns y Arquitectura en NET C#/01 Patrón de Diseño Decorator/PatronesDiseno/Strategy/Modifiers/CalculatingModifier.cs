using Strategy.Common;

namespace Strategy.Modifiers
{
    public abstract class CalculatingModifier : IPrecioModifier
    {
        private IDeduction? Deduction { get; }

        protected CalculatingModifier(IDeduction? deduction)
        {
            Deduction = deduction;
        }

        public (Money first, Money second) ApplyTo(Money a, Money b) =>
            ApplyTo(a, b, Deduction!.From(a, b));


        protected abstract (Money first, Money second) ApplyTo(
            Money a, Money b, Money deduction);
    }
}
