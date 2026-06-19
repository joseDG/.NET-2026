using Strategy.Common;

namespace Strategy
{
    public interface IDeduction
    {
        Money From(Money a, Money b);
    }
}
