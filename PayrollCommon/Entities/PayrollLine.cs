using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollCommon.Entities
{
    public class PayrollLine
    {
        public int PayWeek { get; set; }
        public decimal GrossPay { get; set; }
        public decimal NetPay { get; set; }
        public decimal Deductions { get; set; }
    }
}
