﻿import { Dependant } from './dependant.model'
export class Employee {
    employeeId: number
    firstName: string;
    lastName: string;
    email: string;
    dependants: Dependant[];

    constructor(id: number, firstName: string, lastName: string, email: string, dependants: Dependant[]) {
        this.employeeId = id,
        this.firstName = firstName,
        this.lastName = lastName,
        this.email = email,
        this.dependants = dependants
    }
}