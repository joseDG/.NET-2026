using Strategy.Common;

namespace Strategy
{
    public interface IPrecioModifier
    {
        (Money first, Money second) ApplyTo(Money a, Money b);
    }
}
