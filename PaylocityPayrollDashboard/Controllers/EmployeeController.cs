using Microsoft.AspNetCore.Mvc;
using PayrollCommon.Entities;
using PayrollCommon.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;

namespace PaylocityPayrollDashboard.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {

        private IEmployeeLogic _employeeLogic { get; set; }

        public EmployeeController(IEmployeeLogic employeeLogic)
        {
            _employeeLogic = employeeLogic;
        }

        [HttpGet("[action]")]
        public IEnumerable<Employee> GetEmployees()
        {
            try
            {
                return this._employeeLogic.GetEmployees();                
            }
            catch (Exception ex)
            {
                // this will log to cosole for now
                throw ex;
            }

        }

        [HttpDelete("[action]")]
        public IActionResult RemoveEmployee([FromBody] int employeeId)
        {
            try
            {
                this._employeeLogic.RemoveEmployee(employeeId);
            
                return StatusCode((int)HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.NotFound);

            }
        }

        [HttpPost("[action]")]
        public IActionResult AddEmployee([FromBody] Employee employee)
        {
            try
            {
                if (employee == null)
                {
                    return StatusCode((int)HttpStatusCode.InternalServerError);
                }
                this._employeeLogic.AddEmployee(employee);

                return StatusCode((int)HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }


        [HttpPut("[action]")]
        public IActionResult UpdateEmployee([FromBody] Employee employee)
        {
            try
            {

                if (employee == null)
                {
                    return StatusCode((int)HttpStatusCode.InternalServerError);
                }

                this._employeeLogic.UpdateEmployee(employee);

                return StatusCode((int)HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.NotFound);

            }
        }
    }
}