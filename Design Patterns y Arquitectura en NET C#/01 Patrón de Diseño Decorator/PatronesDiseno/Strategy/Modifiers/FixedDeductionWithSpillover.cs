using Strategy.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy.Modifiers
{
    public class FixedDeductionWithSpillover : IPrecioModifier
    {
        private Money? Amount { get; }

        public FixedDeductionWithSpillover(Money? amount)
        {
            Amount = amount;
        }

        public (Money first, Money second) ApplyTo(Money a, Money b)
        { 
            var deduct = b >= Amount! ? Amount : b;
            var spill = Amount! - deduct!;
            var deductSpill = a >= spill ? spill : a;

            return (a - deductSpill, b - deduct!);
        }
        
    }
}
