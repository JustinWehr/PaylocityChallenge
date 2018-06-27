
using PayrollCommon.Interfaces;
using System.Collections.Generic;

namespace PayrollCommon.Entities
{
    public class Employee: IPerson
    {
        public int EmployeeId  { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<Dependant> Dependants { get; set; }

        public Employee (int employeeId, string firstName, string lastName, string email,
                         List<Dependant> dependants)
        {
            EmployeeId = employeeId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Dependants = dependants;
        }

    }
}
