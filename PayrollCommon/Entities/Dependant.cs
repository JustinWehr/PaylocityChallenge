using PayrollCommon.Interfaces;

namespace PayrollCommon.Entities
{
    public class Dependant : IPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
