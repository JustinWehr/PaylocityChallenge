import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import { Employee } from './employee.model'

@Injectable()
export class EmployeeService {

    private employees: Employee[] = new Array<Employee>();

    constructor(private httpClient: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    }

    public GetEmployees(): Observable<Employee[]>
    {
        return this.httpClient.get<Employee[]>(this.baseUrl + 'api/Employee/GetEmployees');
    }

    public AddEmployee(employee: Employee) {

        return this.httpClient.post(this.baseUrl + 'api/Employee/AddEmployee', employee);
    } 

    public UpdateEmployee(employee: Employee) {

        return this.httpClient.put(this.baseUrl + 'api/Employee/UpdateEmployee', employee);
    }

    public RemoveEmployee(employeeId: number) {

        const httpOptions = {
            headers: new HttpHeaders({ 'Content-Type': 'application/json' }), body: employeeId
        };

        return this.httpClient.delete(this.baseUrl + 'api/Employee/RemoveEmployee', httpOptions);
    }

}