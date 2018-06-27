using PayrollCommon.Entities;
using PayrollCommon.Interfaces;
using System;
using System.Collections.Generic;

namespace PaylocityComponents.Logic
{    
    public class PayrollLogic
    {
        private const int _payWeeks = 26;
        private const int _payAmount = 2000;
        private const int _employeeDeduction = 1000;
        private const int _dependantDeduction = 500;

        private IPayrollRuleLogic _payrollRuleLogic;

        public PayrollLogic(IPayrollRuleLogic payrollRuleLogic)
        {
            _payrollRuleLogic = payrollRuleLogic;
        }

        public PayrollDetail CalculatePayroll(Employee employee)
        {
            var payLines = new List<PayrollLine>();

            payLines = CreatePayrollLines(employee);

            var payDetail = new PayrollDetail()
            {
                Employee = employee,
                PayrollLines = payLines,
                Salary = _payAmount * _payWeeks
            };

            return payDetail;
        }

        private List<PayrollLine> CreatePayrollLines(Employee employee)
        {
            var payLines = new List<PayrollLine>();
            var deducitons = CalculatePayrollLineDeduction(employee);

            for (int i = 0; i < _payWeeks; i++)
            {
                //Move to its own method
                var payLine = new PayrollLine()
                {
                    Deductions = deducitons,
                    GrossPay = _payAmount,
                    NetPay = _payAmount - deducitons,
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
            var discountedDeduction = 0.0m;

            //pull rules
            var discountRules = _payrollRuleLogic.GetPayrollRules();
           
            //process employee
            discountRules.ForEach(rule => discountPercentage += rule.GetDiscount(employee));

            discountedDeduction = CalculateDiscountedDeduction(_employeeDeduction, CalculateDiscountAmount(_employeeDeduction, discountPercentage));

            totalDeduction += (discountedDeduction / _payWeeks);

            // process dependants
            foreach (var dependant in employee.Dependants)
            {
                discountPercentage = 0.0m;

                discountRules.ForEach(rule => discountPercentage += rule.GetDiscount(dependant));

                discountedDeduction = CalculateDiscountedDeduction(_dependantDeduction, CalculateDiscountAmount(_dependantDeduction, discountPercentage));

                totalDeduction += (discountedDeduction) / _payWeeks;
            }

            return totalDeduction;
        }  
        
        private decimal CalculateDiscountAmount(decimal totalDeduction, decimal discountPercentage)
        {
            if (discountPercentage == 1.0m)
                return 0.0m;
            
            return Decimal.Multiply(totalDeduction, discountPercentage);
        }

        private decimal CalculateDiscountedDeduction(decimal totalDeduction, decimal deductionDiscountAmount)
        {
            return Decimal.Subtract(totalDeduction, deductionDiscountAmount);
        }
    }
}
