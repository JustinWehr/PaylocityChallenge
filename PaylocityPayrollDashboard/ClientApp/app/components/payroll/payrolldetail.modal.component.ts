import { Component, Input,  Output, EventEmitter } from '@angular/core';
import { PayrollDetail } from "./payrollDetail.model";
import { PayrollLine } from "./payrollline.model";
import { PayrollService } from "./payroll.service";

@Component({
    selector: 'payrollModal',
    templateUrl: './payrolldetail.modal.component.html'
})
export class PayrollDetailModalComponent {
    @Input() display: boolean = false;
    @Input() employeeId: number;
    @Output() closedPayroll = new EventEmitter<boolean>();

    public payrollDetail: PayrollDetail = new PayrollDetail;
    private showPayrollDetail: boolean = false;

    constructor(private payrollService: PayrollService) { }

    public ngOnChanges() {

        if (this.display) {
           this.calculateBenefits();  
        }
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
        this.closedPayroll.emit(false);
    }
}