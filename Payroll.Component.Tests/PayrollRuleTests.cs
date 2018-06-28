using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaylocityComponents.Logic;
using PaylocityComponents.Logic.Rules;
using PayrollCommon.Entities;
using PayrollCommon.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Payroll.Component.Tests
{
    [TestClass]
    public class PayrollRuleTests
    {
        [TestMethod]
        public void GetPayrollRulesTest()
        {
            var rules = new PayrollRuleLogic().GetPayrollRules();

            Assert.IsTrue(rules.Any());
        }

        [TestMethod]
        public void RunNameRule_HasDiscount()
        {
            var rule = new NameDiscountRule();

            IPerson al = new Employee(1, "Al", "Bundy", new List<Dependant>());

            Assert.IsTrue(rule.GetDiscount(al) > 0.0m);
        }

        [TestMethod]
        public void RunNameRule_NoDiscount()
        {
            var rule = new NameDiscountRule();

            IPerson rocky = new Employee(1, "Rocky", "Balboa", new List<Dependant>());

            Assert.IsTrue(rule.GetDiscount(rocky) == 0.0m);
        }
    }
}
