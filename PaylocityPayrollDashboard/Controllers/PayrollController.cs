using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PayrollCommon.Entities;
using PayrollCommon.Interfaces;
using System;

namespace PaylocityPayrollDashboard.Controllers
{
    [Route("api/[controller]")]
    public class PayrollController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IPayrollLogic _payrollLogic;
        private readonly IEmployeeLogic _employeeLogic;

        public PayrollController(IEmployeeLogic employeeLogic, IPayrollLogic payrollLogic, IConfiguration configuration)
        {
            _configuration = configuration;
            _payrollLogic = payrollLogic;
            _employeeLogic = employeeLogic;
        }

        [HttpGet("[action]")]
        public PayrollDetail CalculatePayroll(int employeeId)
        {
            try
            {
                var payrollConfig = GetPayrollConfiguration();

                var employee = _employeeLogic.GetEmployee(employeeId);

                return this._payrollLogic.CalculatePayroll(employee, payrollConfig);
            }
            catch (Exception ex)
            {
                // this will log to cosole for now
                throw ex;
            }
        }

        private PayrollConfiguration GetPayrollConfiguration()
        {
            return  _configuration.GetSection("PayrollSettings").Get<PayrollConfiguration>();          
        }
    }
}