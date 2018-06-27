using System.Collections.Generic;

namespace PayrollCommon.Interfaces
{
    public interface IPayrollRuleLogic
    {
        List<IPayrollDiscountRule> GetPayrollRules();
    }
}
