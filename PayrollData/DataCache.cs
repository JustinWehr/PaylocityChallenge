using PayrollCommon.Entities;
using System.Collections.Generic;

namespace PayrollData
{
    public static class DataCache
    {
        public static List<Employee> Employees = new List<Employee>
        {
            new Employee(1, "Rocky", "Balboa", new List<Dependant>() { new Dependant() { FirstName = "Test", LastName ="Last" },
                                                                                           new Dependant() { FirstName = "Test", LastName ="Last"  } }),
            new Employee(2, "Luke", "Skywalker", new List<Dependant>() { new Dependant() { FirstName = "Test", LastName ="Last"  },
                                                                                           new Dependant() { FirstName = "Test", LastName ="Last"  } }),
            new Employee(3, "SpongeBob", "SquarePants",  new List<Dependant>()),
            new Employee(4, "James", "Morrison",  new List<Dependant>())
        };
    }
}
