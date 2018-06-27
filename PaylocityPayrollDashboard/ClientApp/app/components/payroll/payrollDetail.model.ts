import { Employee } from '../employee/employee.model'
import { PayrollLine } from './payrollline.model'

export class PayrollDetail {
    Employee: Employee;
    Paylines: PayrollLine[];
    LastName: string;
    Email: string;
    Dependants: string[];

}