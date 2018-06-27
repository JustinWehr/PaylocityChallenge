using System;
using System.Collections.Generic;

namespace PayrollCommon.Entities
{
    public class PayrollDetail
    {
        public Employee Employee { get; set; }
        public Decimal Salary { get; set; }
        public List<PayrollLine> PayrollLines { get; set; }
    }
}
