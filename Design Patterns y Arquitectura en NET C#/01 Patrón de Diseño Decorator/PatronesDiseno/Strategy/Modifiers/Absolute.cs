using Strategy.Common;

namespace Strategy.Modifiers
{
    public class Absolute : IDeduction
    {
        private Money? Amount { get; }

        public Absolute(Money? amount)
        {
            Amount = amount;
        }

        public Money From(Money a, Money b) =>
               Amount!;
        
    }
}
