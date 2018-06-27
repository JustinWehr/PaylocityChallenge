using PayrollCommon.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PaylocityComponents.Logic
{
    public class PayrollRuleLogic : IPayrollRuleLogic
    {
        public List<IPayrollDiscountRule> GetPayrollRules()
        {
            var assembly = Assembly.GetExecutingAssembly();

            var types = (from type in assembly.GetTypes()
                         where type.GetInterfaces().Contains(typeof(IPayrollDiscountRule))
                         && type.GetConstructor(Type.EmptyTypes) != null
                         select type).ToList();

            return types.Select(type => (IPayrollDiscountRule)Activator.CreateInstance(type)).ToList();
        }
    }
}
