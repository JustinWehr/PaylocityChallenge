
namespace PayrollCommon.Interfaces
{
    public interface IPayrollDiscountRule
    {
        decimal GetDiscount(IPerson person);
    }
}
