import { Employee } from '../employee/employee.model'
import { PayrollLine } from './payrollline.model'

export interface IPayrollDetail {
    Employee: Employee;
    Salary: number;
    Deductions: number;
    Paylines: PayrollLine[];
}