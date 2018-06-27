using System;

using Microsoft.AspNetCore.Mvc;
using PaylocityComponents.Logic;
using PayrollCommon.Entities;
using PayrollCommon.Interfaces;

namespace PaylocityPayrollDashboard.Controllers
{
    [Route("api/[controller]")]
    public class PayrollController : Controller
    {
        private PayrollLogic _payrollLogic { get; set; }
        private IEmployeeLogic _employeeLogic { get; set; }       

        public PayrollController(IEmployeeLogic employeeLogic, IPayrollRuleLogic payrollLogic)
        {
            _payrollLogic = new PayrollLogic(payrollLogic);
            _employeeLogic = employeeLogic;
        }

        [HttpGet("[action]")]
        public PayrollDetail CalculatePayroll(int employeeId)
        {
            try
            {
                using (var logic = _employeeLogic)
                {
                    var employee = logic.GetEmployee(employeeId);
                    return  this._payrollLogic.CalculatePayroll(employee);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}