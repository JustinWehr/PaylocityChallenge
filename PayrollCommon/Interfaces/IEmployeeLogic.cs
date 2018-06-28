using PayrollCommon.Entities;
using System;
using System.Collections.Generic;

namespace PayrollCommon.Interfaces
{
    public interface IEmployeeLogic
    {
        Employee GetEmployee(int employeeId);
        List<Employee> GetEmployees();
        void AddEmployee(Employee employee);
        void RemoveEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
    }
}
