using PayrollCommon.Entities;
using System.Collections.Generic;

namespace PayrollData
{
    public static class DataCache
    {
        public static List<Employee> Employees = new List<Employee>
        {
            new Employee(1, "Rocky", "Balboa", "rockyB@gmail.com", new List<Dependant>() { new Dependant() { FirstName = "Test", LastName ="Last" },
                                                                                           new Dependant() { FirstName = "Test", LastName ="Last"  } }),
            new Employee(2, "Luke", "Skywalker", "rockyB@gmail.com", new List<Dependant>() { new Dependant() { FirstName = "Test", LastName ="Last"  },
                                                                                           new Dependant() { FirstName = "Test", LastName ="Last"  } }),
            new Employee(3, "SpongeBob", "SquarePants", "rockyB@gmail.com", new List<Dependant>()),
            new Employee(4, "James", "Morrison", "rockyB@gmail.com", new List<Dependant>())
        };
    }
}
