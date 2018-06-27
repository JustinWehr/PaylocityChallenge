export class Employee {
    EmployeeId: number;
    FirstName: string;
    LastName: string;
    StartDate: Date;

    constructor(id: number, firstName: string, lastName: string, startDate: Date) {
        this.EmployeeId = id,
        this.FirstName = firstName,
        this.LastName = lastName,
        this.StartDate = startDate
    }
}