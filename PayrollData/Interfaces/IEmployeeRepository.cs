using PayrollCommon.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollData.Interfaces
{
   public  interface IEmployeeRepository
    {
        Employee GetEmployee(int employeeId);
        List<Employee> GetEmployees();
        void AddEmployee(Employee employee);
        void RemoveEmployee(int employeeId);
        void UpdateEmployee(Employee employee);
    }
}
