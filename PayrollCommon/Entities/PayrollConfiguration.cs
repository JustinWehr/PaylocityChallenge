using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollCommon.Entities
{
    public class PayrollConfiguration
    {
        public int PayWeeks { get; set; }
        public int WeeklyPay { get; set; }
        public int EmployeeDeduction { get; set; }
        public int DependantDeduction { get; set; }
    }
}
