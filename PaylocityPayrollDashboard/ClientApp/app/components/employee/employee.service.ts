import { Injectable, Inject } from '@angular/core';
import { Http, RequestOptions, Headers } from '@angular/http';
//import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import { Employee } from './employee.model'

@Injectable()
export class EmployeeService {

    private employees: Employee[] = new Array<Employee>();

    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) {
    }

    public GetEmployees(): Observable<any>
    {
        return this.http.get(this.baseUrl + 'api/Employee/GetEmployees')
            .map((response: any) => response.json());
    }

    public AddEmployee(employee: Employee) {
        console.log('made It add service method');
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });
        return this.http.post(this.baseUrl + 'api/Employee/AddEmployee', employee, options);
    } 

    public UpdateEmployee(employee: Employee) {
        console.log('made It update service method');
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });
        return this.http.put(this.baseUrl + 'api/Employee/UpdateEmployee', employee, options);
    }

    public RemoveEmployee(employee: Employee) {

        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers, body: employee });
        return this.http.delete(this.baseUrl + 'api/Employee/RemoveEmployee', options);

    }

}