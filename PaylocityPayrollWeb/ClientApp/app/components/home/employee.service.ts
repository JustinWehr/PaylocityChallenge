import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Employee } from './employee.model'

@Injectable()
export class EmployeeService {

    private employees: Employee[] = new Array<Employee>();


    constructor() {

        this.employees.push(new Employee(1, 'Rocky', 'Balboa', new Date('10/02/2015')));
        this.employees.push(new Employee(2, 'Luke', 'Skywalker', new Date('10/02/2015')));
        this.employees.push(new Employee(3, 'SpongeBob', 'SquarePants', new Date('10/02/2015')));
        this.employees.push(new Employee(4, 'James', 'Morrison', new Date('10/02/2015')));
    }

    public GetEmployees(): Employee[]
    {

        return this.employees;
    }

    public AddEmployee(employee: Employee) {

        this.employees.push(employee);
    } 

    public UpdateEmployee() {

    }

    public RemoveEmployee() {

    }

}