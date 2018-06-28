import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams  } from '@angular/common/http'
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import { IPayrollDetail } from './payrollDetail.model'
@Injectable()
export class PayrollService {

    constructor(private httpClient: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
        
    }

    public CalculatePayroll(employeeId: number): Observable<IPayrollDetail> {

        const params = new HttpParams().set('employeeId', employeeId.toString());

        return this.httpClient.get<IPayrollDetail>(this.baseUrl + 'api/Payroll/CalculatePayroll', { params });
    }
}