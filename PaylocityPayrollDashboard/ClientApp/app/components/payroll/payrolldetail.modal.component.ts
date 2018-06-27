import { Component, Input, AfterViewInit, Output, EventEmitter } from '@angular/core';
import { PayrollDetail } from "./payrollDetail.model";
import { PayrollLine } from "./payrollline.model";
import { PayrollService } from "./payroll.service";

@Component({
    selector: 'payrollModal',
    templateUrl: './payrolldetail.modal.component.html'
})
export class PayrollDetailModalComponent implements AfterViewInit {
    @Input() showCalculatedPayroll: boolean;
    @Input() employeeId: number;
    @Output() closedPayroll = new EventEmitter<boolean>();

    public payrollDetail: PayrollDetail = new PayrollDetail;
    private showPayrollDetail: boolean = false;

    constructor(private payrollService: PayrollService) { }

    ngAfterViewInit() {
        this.calculateBenefits();  
    }

    calculateBenefits(){

        this.payrollService.CalculatePayroll(this.employeeId).subscribe(result => {
            if (result != null) {
                this.payrollDetail = result as PayrollDetail;
                this.showPayrollDetail = true;
            }           
        }, error => console.error(error));      
    }

    close() {  
        console.log('Test payroll close');
        this.closedPayroll.emit(false);
    }
}