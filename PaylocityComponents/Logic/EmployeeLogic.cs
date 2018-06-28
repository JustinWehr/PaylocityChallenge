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
        private readonly IEmployeeRepository _data;

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
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));

            }

            this._data.AddEmployee(employee);
        }

        public void RemoveEmployee(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }

            this._data.RemoveEmployee(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));

            }

            this._data.UpdateEmployee(employee);
        }
    }
}
