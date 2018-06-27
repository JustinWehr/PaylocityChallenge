import { Injectable, Inject } from '@angular/core';
import { Http, RequestOptions, Headers, URLSearchParams } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import { PayrollDetail } from './payrollDetail.model'
@Injectable()
export class PayrollService {

    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) {
        
    }

    public CalculatePayroll(employeeId: number): Observable<PayrollDetail> {
        let params = new URLSearchParams();
        params.append("employeeId", employeeId.toString())

        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers, search: params });

        
        return this.http.get(this.baseUrl + 'api/Payroll/CalculatePayroll', options)
            .map((response: any) => response.json() as PayrollDetail);
    }
}