using Strategy.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy.Modifiers
{
    public class RelativeToTotal : IDeduction
    {

        private decimal Factor { get; }

        public RelativeToTotal(decimal factor)
        {
            Factor = factor;
        }

        public Money From(Money a, Money b) =>
            Factor * (a + b);
       
    }
}
