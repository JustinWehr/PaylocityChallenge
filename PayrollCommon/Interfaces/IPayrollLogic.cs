using PayrollCommon.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollCommon.Interfaces
{
    public interface IPayrollLogic
    {
        PayrollDetail CalculatePayroll(Employee employee);
    }
}
