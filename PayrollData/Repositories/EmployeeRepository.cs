using PayrollCommon.Entities;
using PayrollData.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PayrollData.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public Employee GetEmployee(int employeeId)
        {
            return DataCache.Employees.Where(e => e.EmployeeId == employeeId).FirstOrDefault();
        }
        public List<Employee> GetEmployees()
        {
            return DataCache.Employees;
        }

        public void AddEmployee(Employee employee)
        { 
                var lastEmployee = DataCache.Employees.OrderByDescending(e => e.EmployeeId).FirstOrDefault();

                employee.EmployeeId = lastEmployee == null ? 1 : lastEmployee.EmployeeId + 1;

                DataCache.Employees.Add(employee);
        }

        public void RemoveEmployee(Employee employee)
        {
            var cacheEmployee = DataCache.Employees.Where(x => x.EmployeeId == employee.EmployeeId).FirstOrDefault();

            if (cacheEmployee != null)
            {
                DataCache.Employees.Remove(cacheEmployee);
            }
        }

        public void UpdateEmployee(Employee employee)
        {
            var cacheEmployee = DataCache.Employees.Where(x => x.EmployeeId == employee.EmployeeId).FirstOrDefault();

            if (cacheEmployee != null)
            {
                //delete old
                DataCache.Employees.Remove(cacheEmployee);

                //add new
                DataCache.Employees.Add(employee);
            }
        }
    }
}
