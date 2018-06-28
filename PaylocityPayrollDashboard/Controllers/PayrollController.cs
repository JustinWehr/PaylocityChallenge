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
        private IPayrollLogic _payrollLogic { get; set; }
        private IEmployeeLogic _employeeLogic { get; set; }

        public PayrollController(IEmployeeLogic employeeLogic, IPayrollLogic payrollLogic)
        {
            _payrollLogic = payrollLogic;
            _employeeLogic = employeeLogic;
        }

        [HttpGet("[action]")]
        public PayrollDetail CalculatePayroll(int employeeId)
        {
            try
            {
                var employee = _employeeLogic.GetEmployee(employeeId);
                return this._payrollLogic.CalculatePayroll(employee);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}