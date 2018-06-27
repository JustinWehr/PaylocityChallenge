using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PalocityComponents.Logic;
using PayrollCommon.Entities;
using PayrollCommon.Interfaces;

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
                return this._employeeLogic.GetEmployees(); ;
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpDelete("[action]")]
        public IActionResult RemoveEmployee([FromBody] Employee employee)
        {
            try
            {
                this._employeeLogic.RemoveEmployee(employee);


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