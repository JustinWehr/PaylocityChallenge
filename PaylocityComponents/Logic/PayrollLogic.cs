using PayrollCommon.Entities;
using PayrollCommon.Interfaces;
using System;
using System.Collections.Generic;

namespace PaylocityComponents.Logic
{    
    public class PayrollLogic : IPayrollLogic
    {
        private const int _payWeeks = 26;
        private const int _payAmount = 2000;
        private const int _employeeDeduction = 1000;
        private const int _dependantDeduction = 500;

        private readonly IPayrollRuleLogic _payrollRuleLogic;

        public PayrollLogic(IPayrollRuleLogic payrollRuleLogic)
        {
            _payrollRuleLogic = payrollRuleLogic;
        }

        public PayrollDetail CalculatePayroll(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }

            var payLines = new List<PayrollLine>();

            payLines = CreatePayrollLines(employee);

            var payDetail = new PayrollDetail()
            {
                Employee = employee,
                PayrollLines = payLines,
                Salary = Math.Round((Decimal)(_payAmount * _payWeeks), 2)
            };

            return payDetail;
        }

        private List<PayrollLine> CreatePayrollLines(Employee employee)
        {
            var payLines = new List<PayrollLine>();
            var deductions = CalculatePayrollLineDeduction(employee);

            for (int i = 0; i < _payWeeks; i++)
            {
                //Move to its own method
                var payLine = new PayrollLine()
                {
                    Deductions = deductions,
                    GrossPay = _payAmount,
                    NetPay = Math.Round((_payAmount - deductions), 2),
                    PayWeek = i + 1
                };

                payLines.Add(payLine);
            }

            return payLines;
        }

        private decimal CalculatePayrollLineDeduction(Employee employee)
        {
            var totalDeduction = 0.0m;
            var discountPercentage = 0.0m;

            //pull rules
            var discountRules = _payrollRuleLogic.GetPayrollRules();
           
            //process employee
            discountRules.ForEach(rule => discountPercentage += rule.GetDiscount(employee));

            totalDeduction += CalculateFinalDeduction(_employeeDeduction, discountPercentage);

            // process dependants
            foreach (var dependant in employee.Dependants)
            {
                discountPercentage = 0.0m;

                discountRules.ForEach(rule => discountPercentage += rule.GetDiscount(dependant));

                totalDeduction += CalculateFinalDeduction(_dependantDeduction, discountPercentage);
            }

            return totalDeduction;
        }  

        private decimal CalculateFinalDeduction( decimal deduction, decimal discountPercentage)
        {
            var discountAmount = CalculateDiscountAmount(deduction, discountPercentage);
            var discountedDeduction = CalculateDiscountedDeduction(deduction, discountAmount);

            return Math.Round((discountedDeduction / _payWeeks), 2);
        }        
        private decimal CalculateDiscountAmount(decimal totalDeduction, decimal discountPercentage)
        {
            if (discountPercentage == 1.0m)
                return 0.0m;

            return Math.Round(Decimal.Multiply(totalDeduction, discountPercentage), 2);
        }

        private decimal CalculateDiscountedDeduction(decimal totalDeduction, decimal deductionDiscountAmount)
        {
            return Math.Round(Decimal.Subtract(totalDeduction, deductionDiscountAmount), 2);
        }
    }
}
