using PayrollCommon.Entities;
using PayrollCommon.Interfaces;
using PayrollData.Interfaces;
using PayrollData.Repositories;
using System;
using System.Collections.Generic;

namespace PalocityComponents.Logic
{
    public class EmployeeLogic : IEmployeeLogic
    {
        private IEmployeeRepository _data;

        public EmployeeLogic(IEmployeeRepository employeeRepository)
        {
            _data = employeeRepository;
        }

        public Employee GetEmployee(int employeeId)
        {
            return this._data.GetEmployee(employeeId);
        }

        public List<Employee> GetEmployees()
        {
            return this._data.GetEmployees();
        }

        public void AddEmployee(Employee employee)
        {
            this._data.AddEmployee(employee);
        }

        public void RemoveEmployee(Employee employee)
        {
            this._data.RemoveEmployee(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            this._data.UpdateEmployee(employee);
        }

        public void Dispose()
        {
            this._data = null;
        }
    }
}
