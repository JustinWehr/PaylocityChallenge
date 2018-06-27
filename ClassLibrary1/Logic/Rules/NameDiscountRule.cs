using PayrollCommon.Interfaces;
using System;

namespace PaylocityComponents.Logic.Rules
{
    public class NameDiscountRule : IPayrollDiscountRule
    {
        private const decimal _discount = .1m;
        private const string _startsWithLetter = "A";

        public decimal GetDiscount(IPerson person)
        {
            var discount = 0.0m;

            if (person == default(IPerson))
                throw new ArgumentNullException(nameof(person));

            if (person.FirstName.StartsWith(_startsWithLetter, StringComparison.InvariantCultureIgnoreCase))
            {
                return _discount;
            }
                
            // default to 1 if there isn't a discount.
            return discount == 0.0m ? 1.0m : discount;
        }
    }
}
