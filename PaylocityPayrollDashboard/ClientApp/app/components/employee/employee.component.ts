import { Component, OnInit } from '@angular/core';

import { EmployeeModalComponent } from './employee.modal.component'
import { Employee } from "./employee.model";
import { EmployeeService } from "./employee.service";

import { GridOptions } from "ag-grid/main";
import { DialogModule, ButtonModule, PanelModule, CalendarModule } from 'primeng/primeng';

@Component({
    selector: 'employee',
    templateUrl: './employee.component.html'
})
export class EmployeeComponent implements OnInit {

    private gridOptions: GridOptions;
    private gridApi;
    private gridColumnApi;
    private selectedEmployee: Employee;
    private editEmployee: boolean = false;
    private closeResult: string
    public enableButtons: boolean = false;

    public rowData: any[];
    public rowSelection = 'single';
    public showEmployeeModal: boolean = false;
    public showCalculatedPayroll: boolean = false;

    public columnDefs = [
        { headerName: 'Id', field: 'employeeId' },
        { headerName: 'FirstName', field: 'firstName' },
        { headerName: 'LastName', field: 'lastName' },
        {
            headerName: 'Dependants',
            valueGetter: function getDependantCount(params) {
                return params.data.dependants.length;
            }}
    ];

    constructor(private employeeService: EmployeeService) {

    }

    ngOnInit() {

        this.refreshEmployees();
    }

    public showEmployeeForm(isEdit: boolean = false) {

        this.showEmployeeModal = true;
        this.editEmployee = isEdit;
    }

    public closeEmployeeForm() {

        console.log(this.selectedEmployee);
        this.showEmployeeModal = false;
        this.editEmployee = false;

    }

    public payrollModalClosed(show: boolean) {

        this.showCalculatedPayroll = show;
    }

    public calculatePayroll() {

        this.showCalculatedPayroll = true;
    }

    public addEmployee(employee: Employee) {

        if (employee != undefined) {

            this.employeeService.AddEmployee(employee).subscribe(result => {
                this.refreshEmployees();

            }, error => console.error(error));
        }

        this.closeEmployeeForm();
        this.gridApi.deselectAll();
    }

    public updateEmployee(employee: Employee) {

        if (employee != undefined) {

            this.employeeService.UpdateEmployee(employee).subscribe(result => {
                this.refreshEmployees();

            }, error => console.error(error));
        }

        this.closeEmployeeForm();
        this.gridApi.deselectAll();
    }

    public deleteEmployee() {

        var selectedRows = this.gridApi.getSelectedRows();

        this.employeeService.RemoveEmployee(selectedRows[0] as Employee).subscribe(result => {

            this.refreshEmployees();

        }, error => console.error(error));
    }

    private refreshEmployees() {

        this.employeeService.GetEmployees().subscribe(result => {
            this.rowData = result as Employee[];

            if (this.gridApi) {

                this.gridApi.setRowData(this.rowData);                 
            }
           
        }, error => console.error(error));
    }
    
    onGridReady(params) {
        this.gridApi = params.api;
        this.gridColumnApi = params.columnApi;
        params.api.sizeColumnsToFit();
    }

    onSelectionChanged() {

        this.selectedEmployee = this.gridApi.getSelectedRows()[0] as Employee;
    }    
}
