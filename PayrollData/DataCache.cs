using PayrollCommon.Entities;
using System.Collections.Generic;

namespace PayrollData
{
    public static class DataCache
    {
        /// <summary>
        /// This is where I would have a DAL. It would be an EF project. 
        /// The data projet would reference the context and use Linq to EF. 
        /// </summary>
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
