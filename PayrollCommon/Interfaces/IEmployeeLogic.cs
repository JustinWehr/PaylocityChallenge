using PayrollCommon.Entities;
using System;
using System.Collections.Generic;

namespace PayrollCommon.Interfaces
{
    public interface IEmployeeLogic : IDisposable
    {
        Employee GetEmployee(int employeeId);
        List<Employee> GetEmployees();
        void AddEmployee(Employee employee);
        void RemoveEmployee(Employee employee);

        void UpdateEmployee(Employee employee);
    }
}
