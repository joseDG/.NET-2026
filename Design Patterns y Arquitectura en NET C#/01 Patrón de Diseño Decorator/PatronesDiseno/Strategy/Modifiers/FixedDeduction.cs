using Strategy.Common;

namespace Strategy.Modifiers
{
    public class FixedDeduction : IPrecioModifier
    {
        private Money Amount { get; }

        public FixedDeduction(Money amount)
        { 
            Amount = amount;
        }
        public (Money first, Money second) ApplyTo(Money a, Money b) =>
           b >= Amount ? (a, b - Amount) : (a, b.Currency.Zero);
       
    }
}
