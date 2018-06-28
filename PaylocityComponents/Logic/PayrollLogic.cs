using PayrollCommon.Entities;
using PayrollCommon.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PaylocityComponents.Logic
{
    public class PayrollLogic : IPayrollLogic
    {
        private readonly IPayrollRuleLogic _payrollRuleLogic;
        private PayrollConfiguration _payrollConfiguration;        

        public PayrollLogic(IPayrollRuleLogic payrollRuleLogic)
        {
            _payrollRuleLogic = payrollRuleLogic;
        }

        public PayrollDetail CalculatePayroll(Employee employee, PayrollConfiguration payrollConfiguration)
        {
            _payrollConfiguration = payrollConfiguration;

            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }



            var payLines = CreatePayrollLines(employee);

            var totaDeductions = Math.Round(payLines.Select(p => p.Deductions).ToList().Sum());

            payLines = CalculateRoundingRemainder(payLines, totaDeductions);

            var payDetail = new PayrollDetail()
            {
                Employee = employee,
                PayrollLines = payLines,
                Deductions = totaDeductions,
                Salary = Math.Round((Decimal)(_payrollConfiguration.WeeklyPay * _payrollConfiguration.PayWeeks))                
            };

            return payDetail;
        }

        private List<PayrollLine> CreatePayrollLines(Employee employee)
        {
            var payLines = new List<PayrollLine>();
            var deductions = CalculatePayrollLineDeduction(employee);

            for (int i = 0; i < _payrollConfiguration.PayWeeks; i++)
            {
                //Move to its own method
                var payLine = new PayrollLine()
                {
                    Deductions = deductions,
                    GrossPay = _payrollConfiguration.WeeklyPay,
                    NetPay = Math.Round((_payrollConfiguration.WeeklyPay - deductions), 2),
                    PayWeek = i + 1
                };

                payLines.Add(payLine);
            }

            return payLines;
        }

        private List<PayrollLine> CalculateRoundingRemainder(List<PayrollLine> payLines, decimal deductions)
        {                      
            payLines.ForEach(p => p.Deductions = Decimal.Round(p.Deductions, 2));

            var payLineSum = payLines.Select(p => p.Deductions).ToList().Sum();

            var totalDifference = deductions - payLineSum;

            if (totalDifference > 0)
            {
                var payline =  payLines.OrderByDescending(p => p.PayWeek).First();
                payline.Deductions += totalDifference;
                payline.NetPay -= totalDifference;
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

            totalDeduction += CalculateFinalDeduction(_payrollConfiguration.EmployeeDeduction, discountPercentage);

            // process dependants
            foreach (var dependant in employee.Dependants)
            {
                discountPercentage = 0.0m;

                discountRules.ForEach(rule => discountPercentage += rule.GetDiscount(dependant));

                totalDeduction += CalculateFinalDeduction(_payrollConfiguration.DependantDeduction, discountPercentage);
            }

            return totalDeduction;
        }  

        private decimal CalculateFinalDeduction( decimal deduction, decimal discountPercentage)
        {
            var discountAmount = CalculateDiscountAmount(deduction, discountPercentage);
            var discountedDeduction = CalculateDiscountedDeduction(deduction, discountAmount);

            return (discountedDeduction / _payrollConfiguration.PayWeeks);
        }        
        private decimal CalculateDiscountAmount(decimal totalDeduction, decimal discountPercentage)
        {
            if (discountPercentage == 0.0m)
                return 0.0m;

            return Decimal.Multiply(totalDeduction, discountPercentage);
        }

        private decimal CalculateDiscountedDeduction(decimal totalDeduction, decimal deductionDiscountAmount)
        {
            return Decimal.Subtract(totalDeduction, deductionDiscountAmount);
        }
    }
}
