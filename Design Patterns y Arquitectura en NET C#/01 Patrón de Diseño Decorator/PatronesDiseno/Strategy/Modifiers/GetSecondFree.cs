using Strategy.Common;

namespace Strategy.Modifiers
{
    public class GetSecondFree : IPrecioModifier
    {
        public (Money first, Money second) ApplyTo(Money a, Money b) =>
                (a, b.Currency.Zero);
    }
}
